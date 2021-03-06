﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace MyTorrent.FragmentStorageProviders
{
    /// <summary>
    /// Provider for storing and retrieving fragment byte data.
    /// </summary>
    public interface IFragmentStorageProvider : IDisposable, IAsyncDisposable
    {
        /// <summary>
        /// <see langword="true"/> if the storage provider and all associated resources allocations were
        /// released ;otherwise <see langword="false"/>.
        /// </summary>
        bool Disposed { get; }

        /// <summary>
        /// Gets how many bytes still fit into this storage provider.
        /// </summary>
        /// <remarks>
        /// Sum of <see cref="AvailableStorageSpace"/> and <see cref="UsedStorageSpace"/> don't have to be constant.
        ///
        /// For Example:
        /// If fragment data is stored on a drive of the filesystem and an other process stores data on the same
        /// drive the <see cref="AvailableStorageSpace"/> can change without any write operations of this
        /// <see cref="IFragmentStorageProvider"/>. 
        /// </remarks>
        /// <exception cref="IOException">
        /// The operation to the underlying storage system failed.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        /// Method were called after this storage provider was disposed.
        /// </exception>
        long AvailableStorageSpace { get; }

        /// <summary>
        /// Gets how many bytes this storage provider already stores.
        /// </summary>
        /// <remarks>
        /// Sum of <see cref="AvailableStorageSpace"/> and <see cref="UsedStorageSpace"/> don't have to be constant.
        ///
        /// For Example:
        /// If fragment data is stored on a drive of the filesystem and an other process stores data on the same
        /// drive the <see cref="AvailableStorageSpace"/> can change without any write operations of this
        /// <see cref="IFragmentStorageProvider"/>. 
        /// </remarks>
        /// <exception cref="IOException">
        /// The operation to the underlying storage system failed.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        /// Method were called after this storage provider was disposed.
        /// </exception>
        long UsedStorageSpace { get; }

        /// <summary>
        /// Gets the maximum allowed storage space usage, in bytes.
        /// </summary>
        /// <remarks>
        /// If 0 is returned, no storage space usage limit was defined.
        /// </remarks>
        /// <exception cref="IOException">
        /// The operation to the underlying storage system failed.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        /// Method were called after this storage provider was disposed.
        /// </exception>
        long StorageSpaceUsageLimit { get; }

        /// <summary>
        /// Gets a collection with hash values of all fragments which are stored by this storage provider.
        /// </summary>
        /// <exception cref="IOException">
        /// The operation to the underlying storage system failed.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        /// Method were called after this storage provider was disposed.
        /// </exception>
        IReadOnlyCollection<string> Fragments { get; }

        /// <summary>
        /// Gets a collection of all active storage allocations.
        /// </summary>
        /// <exception cref="IOException">
        /// The operation to underlying storage system failed.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        /// Method were called after this storage provider was disposed.
        /// </exception>
        IReadOnlyCollection<IStorageSpaceAllocationToken> Allocations { get; }

        /// <summary>
        /// Asynchronously allocates a specific amount of storage.
        /// </summary>
        /// <param name="size">
        /// Amount of storage in bytes that should be allocated.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous allocation operation and wraps the
        /// allocation token associated to the resources that were reserved by this operation.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="size"/> is negative.
        /// </exception>
        /// <exception cref="StorageSpaceAllocationException">
        /// Throws if the needed resources to allocate could ne be allocated.
        /// </exception>
        /// <exception cref="IOException">
        /// Throws if the operation to underlying storage system to allocate the specified space failed.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        /// Method were called after this storage provider was disposed.
        /// </exception>
        Task<IStorageSpaceAllocationToken> AllocateStorageSpaceAsync(long size);

        /// <summary>
        /// Asynchronously checks if a fragment with a specific hash value is stored.
        /// </summary>
        /// <param name="fragmentHash">
        /// The hash value of the file fragment to look for.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation an wraps <see langword="true"/> if a fragment
        /// with the specified hash value is stored; otherwise <see langword="false"/>.
        /// (<see langword="false"/> will be returned especially if <paramref name="fragmentHash"/> is
        /// <see langword="null"/> or <paramref name="fragmentHash"/> stores a hash value in an invalid format.)
        /// </returns>
        /// <exception cref="IOException">
        /// The operation to underlying storage system to check if the fragment is stored failed.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        /// Method were called after this storage provider was disposed.
        /// </exception>
        ValueTask<bool> IsFragmentStoredAsync(string fragmentHash);

        /// <summary>
        /// Asynchronously gets the size in bytes of a fragment with specific hash value that is stored.
        /// </summary>
        /// <param name="fragmentHash">
        /// The hash value of the file fragment to look for.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation an wraps a positive 64-bit integer that indicates the size of the fragment
        /// with the specified hash value if it is stored; otherwise -1.
        /// (-1 will be returned especially if <paramref name="fragmentHash"/> is
        /// <see langword="null"/> or <paramref name="fragmentHash"/> stores a hash value in an invalid format.)
        /// </returns>
        /// <exception cref="IOException">
        /// The operation to underlying storage system to get the storage size of the specified fragment failed.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        /// Method were called after this storage provider was disposed.
        /// </exception>
        ValueTask<long> GetFragmentStorageSizeAsync(string fragmentHash);

        /// <summary>
        /// Asynchronously gets the byte data of a stored fragment.
        /// </summary>
        /// <remarks>
        /// Use <seealso cref="ReadFragment(string, bool)"/> for large fragment sizes.
        /// If an object is greater than or equal to 85,000 bytes in size, it’s considered a 
        /// large object and ends up on the <a href="https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/large-object-heap">large object heap</a>.
        /// </remarks>
        /// <param name="fragmentHash">
        /// The hash value of the fragment whose data should be read.
        /// </param>
        /// <param name="delete">
        /// <see langword="true"/> if the fragment should be deleted from this <see cref="IFragmentStorageProvider"/>
        /// after the fragment data has been read; otherwise <see langword="false"/>.
        /// Remarks: The delete operation is performed after the last reader finished reading. Be aware of that when
        /// multiple threads start reading the same fragment.
        /// </param>
        /// <param name="cancellationToken">
        /// The token to monitor for cancellation requests. The default value is None.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous read operation and wraps the byte data of the specified fragment.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Throws if <paramref name="fragmentHash"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="FormatException">
        /// Throws if <paramref name="fragmentHash"/> stores an value that represents no valid hash.
        /// </exception>
        /// <exception cref="KeyNotFoundException">
        /// Throws if the <see cref="IFragmentStorageProvider"/> doesn't stores a fragment with the hash <paramref name="fragmentHash"/>.
        /// </exception>
        /// <exception cref="IOException">
        /// The operation to underlying storage system to read the fragment data failed.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        /// Method were called after this storage provider was disposed.
        /// </exception>
        Task<byte[]> GetFragmentAsync(string fragmentHash, bool delete = false, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Returns a <see cref="Stream"/> to read the byte data of the specified fragment from.
        /// </summary>
        /// <remarks>
        /// You can use <seealso cref="GetFragmentAsync(string, bool, CancellationToken?)"/> to read small fragments.
        /// </remarks>
        /// <param name="fragmentHash">
        /// The hash value of the fragment whose data should be read.
        /// </param>
        /// <param name="delete">
        /// <see langword="true"/> if the fragment should be deleted from this <see cref="IFragmentStorageProvider"/> after
        /// the returned <see cref="Stream"/> was closed; otherwise <see langword="false"/>.
        /// Remarks: The delete operation is performed after the last reader finished reading. Be aware of that when multiple
        /// threads start reading the same fragment.
        /// </param>
        /// <returns>
        /// A <see cref="Stream"/> to read the byte data of the specified fragment from.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Throws if <paramref name="fragmentHash"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="FormatException">
        /// Throws if <paramref name="fragmentHash"/> stores an value that represents no valid hash.
        /// </exception>
        /// <exception cref="KeyNotFoundException">
        /// Throws if the <see cref="IFragmentStorageProvider"/> doesn't stores a fragment with the hash <paramref name="fragmentHash"/>.
        /// </exception>
        /// <exception cref="IOException">
        /// The operation to the underlying storage system failed.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        /// Method were called after this storage provider was disposed.
        /// </exception>
        Stream ReadFragment(string fragmentHash, bool delete = false);

        /// <summary>
        /// Asynchronously stores the byte data of a fragment.
        /// </summary>
        /// <remarks>
        /// Use <seealso cref="WriteFragment(string,long,IStorageSpaceAllocationToken)"/> for large fragment sizes.
        /// 
        /// If an object is greater than or equal to 85,000 bytes in size, it’s considered a large object and ends up on
        /// the <a href="https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/large-object-heap">large object heap</a>.
        /// </remarks>
        /// <param name="fragmentHash">
        /// The hash of the fragment whose data should be stored.
        /// </param>
        /// <param name="data">
        /// The byte data of the fragment to store.
        /// </param>
        /// <param name="allocationToken">
        /// The allocation token for the in advance allocated storage space where the byte data of the specified fragment should be stored.
        /// </param>
        /// <param name="cancellationToken">
        /// The token to monitor for cancellation requests. The default value is None.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous write operation.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Throws if <paramref name="fragmentHash"/> or <paramref name="data"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Throws if an fragment with the same hash value already exists in this <see cref="IFragmentStorageProvider"/>.
        /// -or- <paramref name="allocationToken"/> was not created by this storage provider.
        /// </exception>
        /// <exception cref="FormatException">
        /// Throws if <paramref name="fragmentHash"/> stores an value that represents no valid hash.
        /// </exception>
        /// <exception cref="StorageSpaceAllocationException">
        /// Fragment size is larger than the remaining storage space.
        /// </exception>
        /// <exception cref="IOException">
        /// The operation to underlying storage system to store the fragment data failed.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        /// <paramref name="allocationToken"/> is not <see langword="null"/> and was already disposed.
        /// -or- Method were called after this storage provider was disposed.
        /// </exception>
        Task StoreFragmentAsync(string fragmentHash, byte[] data, IStorageSpaceAllocationToken? allocationToken = null, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Returns a stream where the byte data of a fragment can be written to, to store the fragment.
        /// </summary>
        /// <remarks>
        /// You can use <seealso cref="StoreFragmentAsync(string, byte[], IStorageSpaceAllocationToken, CancellationToken?)"/> to store small fragments.
        /// </remarks>
        /// <param name="fragmentHash">
        /// The hash value of the fragment whose data should be stored.
        /// </param>
        /// <param name="fragmentSize">
        /// Specifies how many bytes the fragment will occupy.
        /// The <see cref="IFragmentStorageProvider"/> can therefore allocate the needed resources or throw an <see cref="IOException"/> if
        /// not enough resources could be allocated.
        /// </param>
        /// <param name="allocationToken">
        /// The allocation token for the in advance allocated storage space where the byte data of the specified fragment should be stored.
        /// </param>
        /// <returns>
        /// A <see cref="Stream"/> where the byte data of a fragment can be written to, to store the fragment.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Throws if <paramref name="fragmentHash"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="FormatException">
        /// Throws if <paramref name="fragmentHash"/> stores an value that represents no valid hash.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Throws if <paramref name="fragmentSize"/> is negative.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Throws if an fragment with the same hash value already exists in this <see cref="IFragmentStorageProvider"/>.
        /// -or- <paramref name="allocationToken"/> was not created by this storage provider.
        /// </exception>
        /// <exception cref="IOException">
        /// The operation to underlying storage system to store the fragment data failed.
        /// </exception>
        /// <exception cref="StorageSpaceAllocationException">
        /// Fragment size is larger than the remaining storage space.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        /// <paramref name="allocationToken"/> is not <see langword="null"/> and was already disposed.
        /// -or- Method were called after this storage provider was disposed.
        /// </exception>
        Stream WriteFragment(string fragmentHash, long fragmentSize, IStorageSpaceAllocationToken? allocationToken = null);

        /// <summary>
        /// Asynchronously deletes the stored data of an fragment from this <see cref="IFragmentStorageProvider"/>.
        /// </summary>
        /// <remarks>
        /// Does nothing if no fragment with the specified <paramref name="fragmentHash"/> was found or the value represents no valid hash. 
        /// </remarks>
        /// <param name="fragmentHash">
        /// The hash value of the fragment whose data should be deleted.
        /// </param>
        /// <param name="wait">
        /// <see langword="true"/> if this operation should be waiting for all pending readers to finish until the fragment was deleted;
        /// <see langword="false"/> if this operation should finish just after the fragment was marked as to delete.
        /// The last pending reader who reads the specified fragment will delete the fragment then.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous delete operation.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Throws if <paramref name="fragmentHash"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="FormatException">
        /// Throws if <paramref name="fragmentHash"/> stores an value that represents no valid hash.
        /// </exception>
        /// <exception cref="IOException">
        /// The operation to underlying storage system to delete the fragment failed.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        /// Method were called after this storage provider was disposed.
        /// </exception>
        Task DeleteFragmentAsync(string fragmentHash, bool wait = false);
    }
}

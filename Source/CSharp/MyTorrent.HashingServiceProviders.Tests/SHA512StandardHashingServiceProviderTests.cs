﻿using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace MyTorrent.HashingServiceProviders.Tests
{
    public class SHA512StandardHashingServiceProviderTests : AbstractHashingServiceProviderTests
    {
        protected override string AlgorithmName => "SHA512";

        protected override int HashValueLength => 128;

        protected override IEnumerable<string> ValidHashValues { get; } = new string[]
        {
            "e68fe78e064700fe6b98e47dc0758a4f966bd027299b685642c607ea376b7d47e68fe78e064700fe6b98e47dc0758a4f966bd027299b685642c607ea376b7d47",
            "E68FE78E064700FE6B98E47DC0758A4F966BD027299B685642C607EA376B7D47E68FE78E064700FE6B98E47DC0758A4F966BD027299B685642C607EA376B7D47",
            "2d2da19605a34e037dbe82173f98a992a530a5fdd53dad882f570d4ba204ef302d2da19605a34e037dbe82173f98a992a530a5fdd53dad882f570d4ba204ef30",
            "2D2DA19605A34E037DBE82173F98A992A530A5FDD53DAD882F570D4BA204EF302D2DA19605A34E037DBE82173F98A992A530A5FDD53DAD882F570D4BA204EF30",
            "6b1e846dedfbcb4e6237e29492e1d6753b491618c005849dcdfc942df66b71286b1e846dedfbcb4e6237e29492e1d6753b491618c005849dcdfc942df66b7128",
            "6B1E846DEDFBCB4E6237E29492E1D6753B491618C005849DCDFC942DF66B71286B1E846DEDFBCB4E6237E29492E1D6753B491618C005849DCDFC942DF66B7128",
            "d9b5f58f0b38198293971865a14074f59eba3e82595becbe86ae51f1d9f1f65ed9b5f58f0b38198293971865a14074f59eba3e82595becbe86ae51f1d9f1f65e",
            "D9B5F58F0B38198293971865A14074F59EBA3E82595BECBE86AE51F1D9F1F65ED9B5F58F0B38198293971865A14074F59EBA3E82595BECBE86AE51F1D9F1F65E",
            "00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000",
            "11111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111",
            "22222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222",
            "33333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333",
            "44444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444",
            "55555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555",
            "66666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666",
            "77777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777",
            "88888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888",
            "99999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999",
            "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA",
            "BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB",
            "CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC",
            "DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD",
            "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE",
            "FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF"
        };

        protected override IEnumerable<string> InvalidHashValues { get; } = new string[]
        {
            null,
            "",
            "",
            "                                                                ",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000",
            "111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111",
            "222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222",
            "333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333",
            "444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444",
            "555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555",
            "666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666",
            "777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777",
            "888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888",
            "999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999",
            "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA",
            "BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB",
            "CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC",
            "DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD",
            "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE",
            "FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
            " D9B5F58F0B38198293971865A14074F59EBA3E82595BECBE86AE51F1D9F1F65ED9B5F58F0B38198293971865A14074F59EBA3E82595BECBE86AE51F1D9F1F65E",
            "D9B5F58F0B38198293971865A14074F59EBA3E82595BECBE86AE51F1D9F1F65ED9B5F58F0B38198293971865A14074F59EBA3E82595BECBE86AE51F1D9F1F65E ",
            "\tD9B5F58F0B38198293971865A14074F59EBA3E82595BECBE86AE51F1D9F1F65ED9B5F58F0B38198293971865A14074F59EBA3E82595BECBE86AE51F1D9F1F65E",
            "D9B5F58F0B38198293971865A14074F59EBA3E82595BECBE86AE51F1D9F1F65ED9B5F58F0B38198293971865A14074F59EBA3E82595BECBE86AE51F1D9F1F65E\t",
            "\nD9B5F58F0B38198293971865A14074F59EBA3E82595BECBE86AE51F1D9F1F65ED9B5F58F0B38198293971865A14074F59EBA3E82595BECBE86AE51F1D9F1F65E",
            "D9B5F58F0B38198293971865A14074F59EBA3E82595BECBE86AE51F1D9F1F65ED9B5F58F0B38198293971865A14074F59EBA3E82595BECBE86AE51F1D9F1F65E\n",
            "ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ",
            "GGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGG",
            "GHIJKLMNOPQRSTUVWXYZghijklmnopqrstuvwxyzGHIJKLMNOPQRSTUVWXYZghijklmnopqrstuvwxyzGHIJKLMNOPQRSTUVWXYZghijklmnopqrstuvwxyzGHIJKLMN"
        };

        protected override IEnumerable<(string, string)> NonNormalizedWithNormalizedHashValues { get; } = new (string, string)[]
        {
            ("e68fe78e064700fe6b98e47dc0758a4f966bd027299b685642c607ea376b7d47e68fe78e064700fe6b98e47dc0758a4f966bd027299b685642c607ea376b7d47", "E68FE78E064700FE6B98E47DC0758A4F966BD027299B685642C607EA376B7D47E68FE78E064700FE6B98E47DC0758A4F966BD027299B685642C607EA376B7D47"),
            ("2d2da19605a34e037dbe82173f98a992a530a5fdd53dad882f570d4ba204ef302d2da19605a34e037dbe82173f98a992a530a5fdd53dad882f570d4ba204ef30", "2D2DA19605A34E037DBE82173F98A992A530A5FDD53DAD882F570D4BA204EF302D2DA19605A34E037DBE82173F98A992A530A5FDD53DAD882F570D4BA204EF30"),
            ("6b1e846dedfbcb4e6237e29492e1d6753b491618c005849dcdfc942df66b71286b1e846dedfbcb4e6237e29492e1d6753b491618c005849dcdfc942df66b7128", "6B1E846DEDFBCB4E6237E29492E1D6753B491618C005849DCDFC942DF66B71286B1E846DEDFBCB4E6237E29492E1D6753B491618C005849DCDFC942DF66B7128"),
            ("d9b5f58f0b38198293971865a14074f59eba3e82595becbe86ae51f1d9f1f65ed9b5f58f0b38198293971865a14074f59eba3e82595becbe86ae51f1d9f1f65e", "D9B5F58F0B38198293971865A14074F59EBA3E82595BECBE86AE51F1D9F1F65ED9B5F58F0B38198293971865A14074F59EBA3E82595BECBE86AE51F1D9F1F65E"),
            ("00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000", "00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"),
            ("11111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111", "11111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111"),
            ("22222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222", "22222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222"),
            ("33333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333", "33333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333"),
            ("44444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444", "44444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444"),
            ("55555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555", "55555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555"),
            ("66666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666", "66666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666"),
            ("77777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777", "77777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777"),
            ("88888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888", "88888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888"),
            ("99999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999", "99999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999"),
            ("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA"),
            ("bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb", "BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB"),
            ("cccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccc", "CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC"),
            ("dddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd", "DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD"),
            ("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee", "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE"),
            ("ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff", "FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF"),
        };

        protected override IEnumerable<(byte[], string)> ByteDataWithCorrectHashValue { get; } = new (byte[], string)[]
        {
            (new byte[] {  }, "CF83E1357EEFB8BDF1542850D66D8007D620E4050B5715DC83F4A921D36CE9CE47D0D13C5D85F2B0FF8318D2877EEC2F63B931BD47417A81A538327AF927DA3E"),
            (new byte[] { 0x00 }, "B8244D028981D693AF7B456AF8EFA4CAD63D282E19FF14942C246E50D9351D22704A802A71C3580B6370DE4CEB293C324A8423342557D4E5C38438F0E36910EE"),
            (new byte[] { 0x54, 0x65, 0x73, 0x74, 0x31, 0x32, 0x33 }, "C12834F1031F6497214F27D4432F26517AD494156CB88D512BDB1DC4B57DB2D692A3DFA269A19B0A0A2A0FD7D6A2A885E33C839C93C206DA30A187392847ED27"),
            (new byte[] { 0x00, 0x48, 0x61, 0x6c, 0x6c, 0x6f, 0x20, 0x57, 0x65, 0x6c, 0x74, 0x21 }, "FCDF17792E03D75D1235CC11B8A38F8CD051A028AA1FDAF157F417A712EBBF48826F9F7435428A0FACB5775DFFEA1AF7AF91A37E8FA7603B0FB5DCADED6EF3E8"),
            (new byte[] { 0x54, 0x45, 0x53, 0x54 }, "7BFA95A688924C47C7D22381F20CC926F524BEACB13F84E203D4BD8CB6BA2FCE81C57A5F059BF3D509926487BDE925B3BCEE0635E4F7BAEBA054E5DBA696B2BF"),
            (new byte[] { 0x6a, 0x66, 0x6c, 0x6b, 0x64, 0x66, 0x67, 0x68, 0x6c, 0x6b, 0x64, 0x73, 0x67, 0x66, 0x6a, 0x67, 0x6c, 0x3c, 0x61, 0x73, 0x6c, 0x6b, 0xc3, 0xb6, 0x61, 0x73, 0x64, 0x66, 0x67, 0x68, 0x71, 0x77, 0x65, 0x72, 0x74, 0x7a, 0x75, 0x30, 0x39, 0xc3, 0xbc, 0x38, 0x36, 0x38, 0x37, 0x35, 0x33, 0x77, 0x65, 0x34, 0x64, 0x66, 0x76, 0x67, 0x62, 0x20, 0x63, 0x66, 0x72, 0x64, 0x74, 0x6a, 0x68, 0x20, 0x62, 0x2c, 0x76, 0x64, 0x66, 0x6a, 0x67, 0x68, 0x6b, 0x20, 0x76, 0x6b, 0x34, 0x38, 0x37, 0x35, 0x7a, 0x38, 0x68, 0x6c, 0x20, 0x69, 0x61, 0x75, 0x67, 0x68, 0x69, 0x75, 0x7a, 0x74, 0x67, 0x6f, 0x33, 0x34, 0x68, 0x66, 0x73, 0x68, 0x66, 0x69, 0x7a, 0x34, 0x33, 0x30, 0x38, 0x39, 0x37, 0x74, 0x20, 0x74, 0x7a, 0x37, 0x38, 0x75, 0x20, 0x69, 0x20, 0x34, 0x33, 0x20, 0x36, 0x74, 0x35, 0x72, 0x66, 0x67, 0x64, 0x63, 0x76, 0x62, 0x6e, 0x68, 0x6d, 0x6a, 0x2c, 0x6b, 0x69, 0x6c, 0x6f, 0x39, 0x38, 0x6f, 0x75, 0x37, 0x6b, 0x7a, 0x6a, 0x74, 0x67, 0x35, 0x66, 0x72, 0x62, 0x20, 0x6e, 0x6d, 0x6d, 0x2c, 0x2e, 0x6c, 0x6f, 0x5d, 0x69, 0x30, 0x6b, 0x6a, 0x66, 0x6c, 0x6b, 0x64, 0x66, 0x67, 0x68, 0x6c, 0x6b, 0x64, 0x73, 0x67, 0x66, 0x6a, 0x67, 0x6c, 0x3c, 0x61, 0x73, 0x6c, 0x6b, 0xc3, 0xb6, 0x61, 0x73, 0x64, 0x66, 0x67, 0x68, 0x71, 0x77, 0x65, 0x72, 0x74, 0x7a, 0x75, 0x30, 0x39, 0xc3, 0xbc, 0x38, 0x36, 0x38, 0x37, 0x35, 0x33, 0x77, 0x65, 0x34, 0x64, 0x66, 0x76, 0x67, 0x62, 0x20, 0x63, 0x66, 0x72, 0x64, 0x74, 0x6a, 0x68, 0x20, 0x62, 0x2c, 0x76, 0x64, 0x66, 0x6a, 0x67, 0x68, 0x6b, 0x20, 0x76, 0x6b, 0x34, 0x38, 0x37, 0x35, 0x7a, 0x38, 0x68, 0x6c, 0x20, 0x69, 0x61, 0x75, 0x67, 0x68, 0x69, 0x75, 0x7a, 0x74, 0x67, 0x6f, 0x33, 0x34, 0x68, 0x66, 0x73, 0x68, 0x66, 0x69, 0x7a, 0x34, 0x33, 0x30, 0x38, 0x39, 0x37, 0x74, 0x20, 0x74, 0x7a, 0x37, 0x38, 0x75, 0x20, 0x69, 0x20, 0x34, 0x33, 0x20, 0x36, 0x74, 0x35, 0x72, 0x66, 0x67, 0x64, 0x63, 0x76, 0x62, 0x6e, 0x68, 0x6d, 0x6a, 0x2c, 0x6b, 0x69, 0x6c, 0x6f, 0x39, 0x38, 0x6f, 0x75, 0x37, 0x6b, 0x7a, 0x6a, 0x74, 0x67, 0x35, 0x66, 0x72, 0x62, 0x20, 0x6e, 0x6d, 0x6d, 0x2c, 0x2e, 0x6c, 0x6f, 0x5d, 0x69, 0x30, 0x6b, 0x6a, 0x66, 0x6c, 0x6b, 0x64, 0x66, 0x67, 0x68, 0x6c, 0x6b, 0x64, 0x73, 0x67, 0x66, 0x6a, 0x67, 0x6c, 0x3c, 0x61, 0x73, 0x6c, 0x6b, 0xc3, 0xb6, 0x61, 0x73, 0x64, 0x66, 0x67, 0x68, 0x71, 0x77, 0x65, 0x72, 0x74, 0x7a, 0x75, 0x30, 0x39, 0xc3, 0xbc, 0x38, 0x36, 0x38, 0x37, 0x35, 0x33, 0x77, 0x65, 0x34, 0x64, 0x66, 0x76, 0x67, 0x62, 0x20, 0x63, 0x66, 0x72, 0x64, 0x74, 0x6a, 0x68, 0x20, 0x62, 0x2c, 0x76, 0x64, 0x66, 0x6a, 0x67, 0x68, 0x6b, 0x20, 0x76, 0x6b, 0x34, 0x38, 0x37, 0x35, 0x7a, 0x38, 0x68, 0x6c, 0x20, 0x69, 0x61, 0x75, 0x67, 0x68, 0x69, 0x75, 0x7a, 0x74, 0x67, 0x6f, 0x33, 0x34, 0x68, 0x66, 0x73, 0x68, 0x66, 0x69, 0x7a, 0x34, 0x33, 0x30, 0x38, 0x39, 0x37, 0x74, 0x20, 0x74, 0x7a, 0x37, 0x38, 0x75, 0x20, 0x69, 0x20, 0x34, 0x33, 0x20, 0x36, 0x74, 0x35, 0x72, 0x66, 0x67, 0x64, 0x63, 0x76, 0x62, 0x6e, 0x68, 0x6d, 0x6a, 0x2c, 0x6b, 0x69, 0x6c, 0x6f, 0x39, 0x38, 0x6f, 0x75, 0x37, 0x6b, 0x7a, 0x6a, 0x74, 0x67, 0x35, 0x66, 0x72, 0x62, 0x20, 0x6e, 0x6d, 0x6d, 0x2c, 0x2e, 0x6c, 0x6f, 0x5d, 0x69, 0x30, 0x6b, 0x6a, 0x66, 0x6c, 0x6b, 0x64, 0x66, 0x67, 0x68, 0x6c, 0x6b, 0x64, 0x73, 0x67, 0x66, 0x6a, 0x67, 0x6c, 0x3c, 0x61, 0x73, 0x6c, 0x6b, 0xc3, 0xb6, 0x61, 0x73, 0x64, 0x66, 0x67, 0x68, 0x71, 0x77, 0x65, 0x72, 0x74, 0x7a, 0x75, 0x30, 0x39, 0xc3, 0xbc, 0x38, 0x36, 0x38, 0x37, 0x35, 0x33, 0x77, 0x65, 0x34, 0x64, 0x66, 0x76, 0x67, 0x62, 0x20, 0x63, 0x66, 0x72, 0x64, 0x74, 0x6a, 0x68, 0x20, 0x62, 0x2c, 0x76, 0x64, 0x66, 0x6a, 0x67, 0x68, 0x6b, 0x20, 0x76, 0x6b, 0x34, 0x38, 0x37, 0x35, 0x7a, 0x38, 0x68, 0x6c, 0x20, 0x69, 0x61, 0x75, 0x67, 0x68, 0x69, 0x75, 0x7a, 0x74, 0x67, 0x6f, 0x33, 0x34, 0x68, 0x66, 0x73, 0x68, 0x66, 0x69, 0x7a, 0x34, 0x33, 0x30, 0x38, 0x39, 0x37, 0x74, 0x20, 0x74, 0x7a, 0x37, 0x38, 0x75, 0x20, 0x69, 0x20, 0x34, 0x33, 0x20, 0x36, 0x74, 0x35, 0x72, 0x66, 0x67, 0x64, 0x63, 0x76, 0x62, 0x6e, 0x68, 0x6d, 0x6a, 0x2c, 0x6b, 0x69, 0x6c, 0x6f, 0x39, 0x38, 0x6f, 0x75, 0x37, 0x6b, 0x7a, 0x6a, 0x74, 0x67, 0x35, 0x66, 0x72, 0x62, 0x20, 0x6e, 0x6d, 0x6d, 0x2c, 0x2e, 0x6c, 0x6f, 0x5d, 0x69, 0x30, 0x6b}, "A66EFF08E9363542FA6F03B179AAF3B59333AA03D512A97450E3A059D42D1ECA45276397CBB162C2558046D8F1C66816996282335C5F9A6082770A7CB4192395")
        };

        protected override IHashingServiceProvider GetInstance()
        {
            IOptions<StandardHashingServiceProviderOptions> options = Options.Create<StandardHashingServiceProviderOptions>(new StandardHashingServiceProviderOptions
            {
                HashAlgorithm = "SHA512"
            });

            return new StandardHashingServiceProvider(options);
        }
    }
}

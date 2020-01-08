package TrackerServer;


/**
* TrackerServer/NetworkInfoHelper.java .
* Generated by the IDL-to-Java compiler (portable), version "3.2"
* from MyTorrent.idl
* Mittwoch, 8. Januar 2020 15:41 Uhr MEZ
*/

abstract public class NetworkInfoHelper
{
  private static String  _id = "IDL:TrackerServer/NetworkInfo:1.0";

  public static void insert (org.omg.CORBA.Any a, TrackerServer.NetworkInfo that)
  {
    org.omg.CORBA.portable.OutputStream out = a.create_output_stream ();
    a.type (type ());
    write (out, that);
    a.read_value (out.create_input_stream (), type ());
  }

  public static TrackerServer.NetworkInfo extract (org.omg.CORBA.Any a)
  {
    return read (a.create_input_stream ());
  }

  private static org.omg.CORBA.TypeCode __typeCode = null;
  private static boolean __active = false;
  synchronized public static org.omg.CORBA.TypeCode type ()
  {
    if (__typeCode == null)
    {
      synchronized (org.omg.CORBA.TypeCode.class)
      {
        if (__typeCode == null)
        {
          if (__active)
          {
            return org.omg.CORBA.ORB.init().create_recursive_tc ( _id );
          }
          __active = true;
          org.omg.CORBA.StructMember[] _members0 = new org.omg.CORBA.StructMember [2];
          org.omg.CORBA.TypeCode _tcOf_members0 = null;
          _tcOf_members0 = org.omg.CORBA.ORB.init ().get_primitive_tc (org.omg.CORBA.TCKind.tk_long);
          _members0[0] = new org.omg.CORBA.StructMember (
            "fragmentSize",
            _tcOf_members0,
            null);
          _tcOf_members0 = org.omg.CORBA.ORB.init ().create_string_tc (0);
          _tcOf_members0 = org.omg.CORBA.ORB.init ().create_sequence_tc (0, _tcOf_members0);
          _members0[1] = new org.omg.CORBA.StructMember (
            "torrentServer",
            _tcOf_members0,
            null);
          __typeCode = org.omg.CORBA.ORB.init ().create_struct_tc (TrackerServer.NetworkInfoHelper.id (), "NetworkInfo", _members0);
          __active = false;
        }
      }
    }
    return __typeCode;
  }

  public static String id ()
  {
    return _id;
  }

  public static TrackerServer.NetworkInfo read (org.omg.CORBA.portable.InputStream istream)
  {
    TrackerServer.NetworkInfo value = new TrackerServer.NetworkInfo ();
    value.fragmentSize = istream.read_long ();
    int _len0 = istream.read_long ();
    value.torrentServer = new String[_len0];
    for (int _o1 = 0;_o1 < value.torrentServer.length; ++_o1)
      value.torrentServer[_o1] = istream.read_string ();
    return value;
  }

  public static void write (org.omg.CORBA.portable.OutputStream ostream, TrackerServer.NetworkInfo value)
  {
    ostream.write_long (value.fragmentSize);
    ostream.write_long (value.torrentServer.length);
    for (int _i0 = 0;_i0 < value.torrentServer.length; ++_i0)
      ostream.write_string (value.torrentServer[_i0]);
  }

}
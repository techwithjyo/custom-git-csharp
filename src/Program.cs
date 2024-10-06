using System;
using System.IO;
using System.IO.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

if (args.Length < 1)
{
    Console.WriteLine("Please provide a command.");
    return;
}

// You can use print statements as follows for debugging, they'll be visible when running tests.
Console.WriteLine("Logs from your program will appear here!");

string command = args[0];

if (command == "init")
{
    // Uncomment this block to pass the first stage
    //
    Directory.CreateDirectory(".git");
    Directory.CreateDirectory(".git/objects");
    Directory.CreateDirectory(".git/refs");
    File.WriteAllText(".git/HEAD", "ref: refs/heads/main\n");
    Console.WriteLine("Initialized git directory");
}
else if (command == "cat-file" && args.Length == 3 && args[1] == "-p")
{
    string blobSha = args[2];
    string objectDir = $".git/objects/{blobSha.Substring(0, 2)}";
    string objectFile = $"{objectDir}/{blobSha.Substring(2)}";

    if (!File.Exists(objectFile))
    {
        Console.WriteLine($"Object {blobSha} not found.");
        return;
    }

    byte[] compressedData = File.ReadAllBytes(objectFile);
    using (var compressedStream = new MemoryStream(compressedData))
    using (var zlibStream = new InflaterInputStream(compressedStream))
    using (var decompressedStream = new MemoryStream())
    {
        zlibStream.CopyTo(decompressedStream);
        byte[] decompressedData = decompressedStream.ToArray();
        string blobData = System.Text.Encoding.UTF8.GetString(decompressedData);
        int nullIndex = blobData.IndexOf('\0');
        string content = blobData.Substring(nullIndex + 1);
        Console.Write(content);
    }
}
else
{
    throw new ArgumentException($"Unknown command {command}");
}
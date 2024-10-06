[![progress-banner](https://backend.codecrafters.io/progress/git/39b2f305-b130-4c04-847f-14f25f15bad2)](https://app.codecrafters.io/users/codecrafters-bot?r=2qF)

This is a starting point for C# solutions to the
["Build Your Own Git" Challenge](https://codecrafters.io/challenges/git).

In this challenge, you'll build a small Git implementation that's capable of
initializing a repository, creating commits and cloning a public repository.
Along the way we'll learn about the `.git` directory, Git objects (blobs,
commits, trees etc.), Git's transfer protocols and more.

**Note**: If you're viewing this repo on GitHub, head over to
[codecrafters.io](https://codecrafters.io) to try the challenge.

# Passing the first stage

The entry point for your Git implementation is in `src/Program.cs`. Study and
uncomment the relevant code, and push your changes to pass the first stage:

```sh
git commit -am "pass 1st stage" # any msg
git push origin master
```

That's all!

# Stage 2 & beyond

Note: This section is for stages 2 and beyond.

1. Ensure you have `dotnet (8.0)` installed locally
1. Run `./your_program.sh` to run your Git implementation, which is implemented
   in `src/Program.cs`.
1. Commit your changes and run `git push origin master` to submit your solution
   to CodeCrafters. Test output will be streamed to your terminal.

# Testing locally

The `your_program.sh` script is expected to operate on the `.git` folder inside
the current working directory. If you're running this inside the root of this
repository, you might end up accidentally damaging your repository's `.git`
folder.

We suggest executing `your_program.sh` in a different folder when testing
locally. For example:

```sh
mkdir -p /tmp/testing && cd /tmp/testing
/path/to/your/repo/your_program.sh init
```

To make this easier to type out, you could add a
[shell alias](https://shapeshed.com/unix-alias/):

```sh
alias mygit=/path/to/your/repo/your_program.sh

mkdir -p /tmp/testing && cd /tmp/testing
mygit init
```

**Personal Notes:**
1.1) **Read a Blob Object:**
   a) Stored as a file in .git/objects.
   b) Contains a header and the blob content, compressed using Zlib.
   c) Format (after decompression): blob <size>\0<content>

1.2) The cat-file Command
Used to view the type, size, and content of an object.
Example usage: git cat-file -p <blob_sha>

1.3) Implementation Steps
Read the blob object file from .git/objects.
Decompress the file using Zlib.
Extract the content from the decompressed data.
Print the content to stdout without a newline.
# C# Word Count (wc) Clone

This repository contains a C# implementation of the traditional Linux `wc` command, which is commonly used to count bytes, words, and lines in text. This project was developed as part of my learning journey with C#, which I started on the 6th April 2024. The aim was to imitate as closely as possible the behavior of the original `wc` application that ships with Linux.

## Features
- Exact behavior imitation of Linux `wc`: The application attempts to closely replicate the functionality and output of the Linux wc command.
- Custom command line option parser: Rather than using third-party libraries, this project features a custom-built parser for handling command line options, providing a great learning experience in handling text and arguments in C#. This custom parser allows for adding options to parse using both POSIX `-v` and `--verbose` GNU conventions. The parser also allows for composite POSIX options (`-abc` being equivalent to `-a -b -c`).

## Motivation

As a new C# learner, my goal was to challenge myself by recreating existing tools in a different programming environment. The choice of `wc` is inspired by John Crickett's [Coding Challenges](https://codingchallenges.fyi/blog/welcome/) blog.

This project not only helped in understanding the basics of C#, but also in grasping more complex concepts like parsing and file handling in a real-world application context. I plan to revisit this project and others like it as I learn more about best practices and advanced features in C#.

## License
This project is open-sourced under the MIT License. See the [LICENSE]() file for more details.

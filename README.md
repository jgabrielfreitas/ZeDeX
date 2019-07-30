# ZeDeX
A simple Partner CR(UD) using DDD

# Requirements
- Docker

# Getting started

1. First of all, start a localhost sqlserver and web api:
```sh
docker-compose build
docker-compose up
```
2. You'll need to create the `Zedex` database and application's data structure.
> Run create_database.sql and create_database_structure.sql respectively

---

# Documentation

When application is running, open [here](http://localhost:39500/index.html) to access docs.
There is a Postman collection that you can find [here](https://www.getpostman.com/collections/6b13a4cc39b714ce69c7)

# License
```
MIT License

Copyright (c) 2019 João Freitas

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

```


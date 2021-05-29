## Password generator

### About:

Simple application that generates passwords with specific lengths and special characters.

### Language and Framework:

* Language: C#
* Framework: netCore 5.0

#### To build docker container:

* OS in the container: Linux

* Command:

```bash
dotnet build -t password-generator:latest .
```

### Tag version
Check latest container tag [version](https://hub.docker.com/repository/docker/moleszek/password-generator/tags?page=1&ordering=last_updated) and change **<x.x>** with proper tag version

### To pull image from docker hub:

* docker pull moleszek/password-generator:<x.x>

### Usage:

* Withouth special characters:

```bash
docker run --rm password-generator:<x.x> -l 20
```

* With special characters:

```bash
docker run --rm password-generator:<x.x> -l 20 --special_char
```

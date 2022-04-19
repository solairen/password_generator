## Password generator

### About:

Simple application that generates passwords with specific lengths and special characters.

### Language and Framework:

* Language: C#
* Framework: netCore 6.0

#### To build docker container:

* OS in the container: Linux

* Command:

```bash
dotnet build -t password-generator:latest .
```

### To pull image from docker hub:

* docker pull moleszek/password-generator:<x.x>

### Usage:

* Withouth special characters:

```bash
docker run --rm password-generator:latest -l 20
```

* With special characters:

```bash
docker run --rm password-generator:latest -l 20 --special_char
```

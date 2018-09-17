#!/bin/bash
docker run -e "REPOSITORY=https://github.com/dolittle/DotNET.Fundamentals.git" -e "COMMIT=beb7544a44dff9283ba2f1d5c3cc8a567dfffa6c" dolittlebuild/dotnet
#docker run -it -e "REPOSITORY=https://github.com/dolittle/DotNET.Fundamentals.git" -e "COMMIT=beb7544a44dff9283ba2f1d5c3cc8a567dfffa6c" dolittlebuild/dotnet /bin/bash
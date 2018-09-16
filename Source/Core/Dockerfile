FROM microsoft/dotnet:2.2-sdk-bionic

RUN apt-get update && \
    apt-get -y install rsync

ENV PATH="/root/.dotnet/tools:${PATH}"
VOLUME [ "/repository" ]
ARG SOURCE=/source

ADD packages.props /build/
ADD build.csproj /build/

WORKDIR /build/

RUN dotnet tool install --global Cake.Tool &&\
    dotnet restore

ADD *.cake /build/

WORKDIR /source/

CMD echo Copy repository &&\
    rsync -rt /repository/ /source/ &&\
    dotnet cake /build/_build.cake --verbosity=Diagnostic
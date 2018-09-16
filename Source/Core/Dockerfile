FROM microsoft/dotnet:2.1-sdk
ENV PATH="/root/.dotnet/tools:${PATH}"

ADD packages.props /build/
ADD build.csproj /build/

WORKDIR /build/

RUN dotnet tool install --global Cake.Tool &&\
    dotnet restore

ADD *.cake /build/

ENTRYPOINT dotnet cake /build/_build.cake --verbosity=Verbose
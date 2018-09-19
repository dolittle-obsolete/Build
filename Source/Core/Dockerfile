FROM microsoft/dotnet:2.2-sdk-bionic

RUN apt-get update && \
    apt-get -y install rsync

ENV PATH="/root/.dotnet/tools:${PATH}"
ENV REPOSITORY=
ENV COMMIT=
ENV SOURCE=/source
ENV VERSION=1.0.0
ENV CAKEFILE=/build/build.cake
ENV CAKE_OPTIONS=

ADD packages.props /build/
ADD build.csproj /build/

WORKDIR /build/

RUN dotnet tool install --global Cake.Tool &&\
    dotnet restore

ADD *.cake /build/

VOLUME [ "/repository", "/packages", "/output", "/publish", "/testresults" ]

CMD echo Copy repository >> /output/log.txt &&\
    rsync -rt /repository/ /source/ >> /output/log.txt &&\
    echo Run with ${CAKEFILE} >> /output/log.txt && \
    dotnet cake ${CAKEFILE} --repository=${REPOSITORY} --commit=${COMMIT} ${CAKE_OPTIONS} --verbosity=Verbose >> /output/log.txt
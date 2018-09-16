FROM microsoft/dotnet:2.2-sdk-bionic

RUN apt-get update && \
    apt-get -y install rsync

ENV PATH="/root/.dotnet/tools:${PATH}"
ENV REPOSITORY=
ENV COMMIT=
ENV SOURCE=/source
ENV CAKEFILE=/build/build.cake
ENV CAKE_OPTIONS=

ADD packages.props /build/
ADD build.csproj /build/

WORKDIR /build/

RUN dotnet tool install --global Cake.Tool &&\
    dotnet restore

ADD *.cake /build/

#CMD echo Copy repository &&\
#    rsync -rt /repository/ /source/ &&\
CMD echo Run with ${CAKEFILE} && \
    dotnet cake ${CAKEFILE} --repository=${REPOSITORY} --commit=${COMMIT} ${CAKE_OPTIONS} --verbosity=Verbose
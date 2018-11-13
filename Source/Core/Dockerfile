FROM microsoft/dotnet:2.2-sdk-bionic

RUN apt-get update && \
    apt-get -y install rsync

ENV PATH="/root/.dotnet/tools:${PATH}"
ENV REPOSITORY=
ENV COMMIT=
ENV SOURCE=/source
ENV BASE_PATH=/Source
ENV VERSION=1.0.0
ENV CAKEFILE=/build/build.cake
ENV CAKE_OPTIONS=
ENV CALLBACK=
ENV PACKAGE=false
ENV PUBLISH=false
ENV FOLDER_WITH_PROJECT_TO_PUBLISH=

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
    dotnet cake ${CAKEFILE} \
            --source_path=${SOURCE} \
            --base_path=${BASE_PATH} \
            --repository=${REPOSITORY} \
            --folder_with_project_to_publish=${FOLDER_WITH_PROJECT_TO_PUBLISH}} \
            --commit=${COMMIT} ${CAKE_OPTIONS} \
            --verbosity=Verbose \
            >> /output/log.txt
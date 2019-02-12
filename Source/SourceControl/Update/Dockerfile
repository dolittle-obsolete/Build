FROM alpine:3.9

LABEL vendor="Dolittle"
LABEL maintainer="jakob@dolittle.com"

ARG BUILD_DATE
ARG COMMIT_SHA

LABEL org.label-schema.schema-version="1.0"
LABEL org.label-schema.build-date="${BUILD_DATE}"
LABEL org.label-schema.name="Git - Update"
LABEL org.label-schema.description="This image updates a local copy of the remote reposity, and checks out the 'master' branch"
LABEL org.label-schema.url="https://github.com/dolittle-platform/continuous_improvement"
LABEL org.label-schema.vcs-url="https://github.com/dolittle-platform/Build"
LABEL org.label-schema.vcs-ref="${COMMIT_SHA}"

RUN apk add --no-cache \
    git

COPY update_repository.sh /usr/bin/update_repository.sh

ENTRYPOINT [ "/bin/sh", "/usr/bin/update_repository.sh" ]
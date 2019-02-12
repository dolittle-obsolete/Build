#!/bin/bash

BUILD_DATE=$(date "+%Y-%m-%d")
COMMIT_SHA=$(git rev-parse HEAD)

docker build -t dolittlebuild/sourcecontrol/git/update:1.0.0 --build-arg BUILD_DATE="$BUILD_DATE" --build-arg COMMIT_SHA="$COMMIT_SHA" ./Update/
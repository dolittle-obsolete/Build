#!/bin/sh

# This script is meant to keep the local repository up to date with the a remote master branch
# Is expects as arguments:
#  $1 - The local repository directory
#  $2 - The remote repository URL

mkdir -p $1
if [ ! -d "$1/.git" ]; then
  # The code has not been cloned yet
  git -C "$1" clone --recursive --branch master $2 .
else
  # There is code, align it with the remote master
  git -C "$1" checkout master
  git -C "$1" fetch --prune --tags 
  git -C "$1" reset --hard origin/master
  git -C "$1" submodule update --recursive
fi
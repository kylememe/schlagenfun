#!/bin/bash

docker run \
--name db \
--env POSTGRES_USER=schlagenuser \
--env POSTGRES_PASSWORD= \
--volume /Users/kylesmith/Repos/schlagenfun/instance/postgres:/var/lib/postgresql/data \
--network=schlagen-net \
--detach \
postgres
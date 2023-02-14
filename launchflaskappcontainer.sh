#!/bin/bash

docker run \
--user=appuser \
--env=FLASK_APP=schlagen_web/__init__.py \
--env=FLASK_ENV=development \
--env=DATABASE_URI='postgresql://schlagenuser:@db:5432/schlagenfun' \
--network=schlagen-net \
--volume=/Users/kylesmith/Repos/schlagenfun/instance:/app/instance \
--workdir=/app \
--publish 32456:5000 \
--label='com.microsoft.created-by=visual-studio-code' \
--runtime=runc \
--detach \
schlagenfun:latest
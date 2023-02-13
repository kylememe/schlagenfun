#!/bin/bash

docker run --user=appuser --env=FLASK_APP=schlagen_web/__init__.py --env=FLASK_ENV=development --volume=/Users/kylesmith/Repos/schlagenfun/instance:/app/instance --workdir=/app -p 32456:5000 --label='com.microsoft.created-by=visual-studio-code' --runtime=runc -d schlagenfun:latest
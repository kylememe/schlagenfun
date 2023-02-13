#!/bin/bash

docker run --name postgresql -e POSTGRES_USER=schlagenuser -e POSTGRES_PASSWORD= -p 5432:5432 -v /Users/kylesmith/Repos/schlagenfun/instance/postgres:/var/lib/postgresql/data -d postgres
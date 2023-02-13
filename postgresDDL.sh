#!/bin/bash

export FLASK_APP="schlagen_web"
export FLASK_ENV="development"

export DATABASE_URI="postgresql://schlagenuser:@localhost:5432/schlagenfun"

flask shell
terraform {
  required_providers {
    aws = {
      source  = "hashicorp/aws"
      version = "~> 4.19.0"
    }
  }

  backend "s3" {
    bucket = "tf-tuts-state-ks12514"
    key = "state"
    region = "us-east-1"
  }
}


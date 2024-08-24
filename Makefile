ROOT_PATH := $(abspath $(lastword $(MAKEFILE_LIST)))
ROOT_DIR :=  $(dir $(ROOT_PATH))
DASHBOARD_DIR = $(ROOT_DIR)/dashboard
API_DIR = $(ROOT_DIR)/api/MfaApi

dev-dashboard:
	cd $(DASHBOARD_DIR) && npm run dev

run-dashboard:
	cd $(DASHBOARD_DIR) && npm run build && npm run start

dev-api:
	cd $(API_DIR) && dotnet watch

run-api:
	cd $(API_DIR) && dotnet run

test-api:
	cd $(API_DIR) && dotnet test
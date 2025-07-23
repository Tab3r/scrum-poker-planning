.DEFAULT_GOAL := help

migration-first: ## Create first migration
	@dotnet ef migrations add InitialCreate --verbose
migration-apply: ## Apply migrations to database
	@dotnet ef database update
migration-drop: ## Drop database
	@dotnet ef database drop
help:
	@grep -E '^[a-zA-Z_-]+:.*?## .*$$' $(MAKEFILE_LIST) | awk 'BEGIN {FS = ":.*?## "}; {printf "\033[36m%-30s\033[0m %s\n", $$1, $$2}'

# GitHub Action - Prepare service params

This GitHub Action helps to prepare service params


## Usage

Add this step in your workflow file
```yaml
-   name: Prepare service params
    id: prepare_service_params
    uses: A-A-S-DevLab/actions-prepare-service-params@v1.0.6
    with:
        env_type: ${{ env.ENV_TYPE }}
        repository_owner: ${{ env.REPOSITORY_OWNER }}
        repository_name: ${{ env.REPOSITORY_NAME }}
        branch_name: ${{ env.BRANCH_NAME }}
        image_version: ${{ env.IMAGE_VERSION }}
        server_name: ${{ env.SERVER_NAME }}
        instance_name: ${{ env.INSTANCE_NAME }}

-   name: Move service params to env
    run: |
        echo "ENV_TYPE=${{steps.prepare_service_params.outputs.env_type}}" >> ${GITHUB_ENV}
        echo "ENV_TYPE_POSTFIX=${{steps.prepare_service_params.outputs.env_type_postfix}}" >> ${GITHUB_ENV}
        echo "REPOSITORY_OWNER=${{steps.prepare_service_params.outputs.repository_owner}}" >> ${GITHUB_ENV}
        echo "REPOSITORY_NAME=${{steps.prepare_service_params.outputs.repository_name}}" >> ${GITHUB_ENV}
        echo "BRANCH_NAME=${{steps.prepare_service_params.outputs.branch_name}}" >> ${GITHUB_ENV}
        echo "IMAGE_VERSION=${{steps.prepare_service_params.outputs.image_version}}" >> ${GITHUB_ENV}
        echo "SERVICE_NETWORK=${{steps.prepare_service_params.outputs.service_network}}" >> ${GITHUB_ENV}
        echo "CONTAINER_NAME=${{steps.prepare_service_params.outputs.container_name}}" >> ${GITHUB_ENV}
        echo "CONTAINER_SHORT_NAME=${{steps.prepare_service_params.outputs.container_short_name}}" >> ${GITHUB_ENV}
        echo "SERVER_NAME=${{steps.prepare_service_params.outputs.server_name}}" >> ${GITHUB_ENV}
        echo "SERVER_SHORT_NAME=${{steps.prepare_service_params.outputs.server_short_name}}" >> ${GITHUB_ENV}
        echo "SERVICE_TARGET_FOLDER=${{steps.prepare_service_params.outputs.service_target_folder}}" >> ${GITHUB_ENV}
        echo "DOMAIN_NAME=${{steps.prepare_service_params.outputs.domain_name}}" >> ${GITHUB_ENV}
        echo "LOCAL_CONFIG_IS_EXIST=${{steps.prepare_service_params.outputs.local_config_is_exist}}" >> ${GITHUB_ENV}
        echo "INSTANCE_NAME=${{steps.prepare_service_params.outputs.instance_name}}" >> ${GITHUB_ENV}
        echo "INSTANCE_NAME_POSTFIX=${{steps.prepare_service_params.outputs.instance_name_postfix}}" >> ${GITHUB_ENV}
```

## Input variables

- `env_type`: Environment type
- `repository_owner`: Repository owner
- `repository_name`: Repository name
- `branch_name`: Branch name
- `image_version`: Image version
- `server_name`: Server name
- `instance_name`: Instance name

## Outputs variables

- `env_type`: Environment type (in lower case)
- `env_type_postfix`: Environment tag (in lower case)
- `repository_owner`: Repository owner (in lower case)
- `repository_name`: Repository name (in lower case)
- `branch_name`: Branch name (in lower case)
- `image_version`: Image version (in lower case)
- `service_network`: Service network (in lower case)
- `container_name`: Container name (in lower case)
- `container_short_name`: Container short name (in lower case)
- `server_name`: Server name (in lower case)
- `server_short_name`: Server short name (in lower case)
- `service_target_folder`: Service target folder (in lower case)
- `domain_name`: Service domain name (in lower case)
- `instance_name`: Instance name (in lower case)
- `instance_name_postfix`: Instance name (in lower case)
provider "azurerm" {
  features {}
}

variable "storage_account_name" {
  description = "The name of the storage account. Must be globally unique."
  type        = string
}

variable "location" {
  description = "The location where the storage account will be created."
  type        = string
  default     = "eastus"
}

variable "resource_group_name" {
  description = "The name of the resource group where the storage account will be created."
  type        = string
}

variable "sku_name" {
  description = "The SKU of the storage account."
  type        = string
  default     = "Standard_LRS"
}

resource "azurerm_resource_group" "rg" {
  name     = var.resource_group_name
  location = var.location
}

resource "azurerm_storage_account" "storage" {
  name                     = var.storage_account_name
  resource_group_name      = azurerm_resource_group.rg.name
  location                 = var.location
  account_tier             = "Standard"
  account_replication_type = "LRS"
  kind                     = "StorageV2"

  tags = {
    environment = "Terraform"
  }
}

output "storage_account_name" {
  description = "The name of the created storage account."
  value       = azurerm_storage_account.storage.name
}

output "storage_account_endpoint" {
  description = "The primary blob endpoint of the storage account."
  value       = azurerm_storage_account.storage.primary_blob_endpoint
}
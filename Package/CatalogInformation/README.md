# List Views

## About

The **List Views** Automation script provides an easy and efficient way to explore the hierarchical structure of DataMiner views. Whether you need to understand how your views are organized or quickly identify all subviews under a specific parent view, this script delivers the information in a clear, indented format that reflects the view hierarchy.

This script is particularly useful for **DataMiner administrators and engineers** who need to audit view structures, troubleshoot view-related issues, or document the organization of their DataMiner system. By supporting both view names and IDs as input, it offers flexibility for different workflows and use cases.

## Key Features

- **Flexible Input Options**: Accept either view names or view IDs, making it easy to query views regardless of how you reference them in your system.

- **Configurable Recursion Depth**: Control how deep the script traverses the view hierarchy, from direct children to multiple levels deep.

- **Clear Hierarchical Display**: View information is logged with indentation that visually represents the hierarchy level, making it easy to understand parent-child relationships at a glance.

- **Comprehensive View Information**: Retrieve both the name and ID of each view in the hierarchy for complete documentation.

## Use Cases

### View Structure Auditing

When managing large DataMiner systems with complex view hierarchies, administrators often need to understand how views are organized. This script allows you to quickly generate a complete map of any view branch, helping you identify organizational patterns, redundancies, or structural issues.

### Documentation and Reporting

Generate structured documentation of your view hierarchy for compliance, handover documentation, or system architecture reviews. The indented format makes it easy to copy the output into documentation or share with team members.

### Troubleshooting View Issues

When investigating issues related to specific views or debugging automation scripts that work with views, having a quick way to list all related views and their IDs can significantly speed up the troubleshooting process.

## Prerequisites

- **DataMiner version**: 10.4 or higher (Main Release)
- **User permissions**: Read access to views in the DataMiner system
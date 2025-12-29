# SLC-AS-GetViews

## Summary

This Automation script retrieves and displays the hierarchical structure of DataMiner views based on a specified root view. The script logs view information (name and ID) with indentation to represent the hierarchy level, allowing users to visualize the organization of views within their DataMiner system. The recursion level determines how deep the script will traverse the view hierarchy.

## Input Arguments

### RootView
- **Type**: Text (string)
- **Description**: The name or ID of the view for which the subviews will be returned. This serves as the starting point for the view hierarchy retrieval.

### RootViewInputType
- **Type**: Multiple choice (string)
- **Description**: Indicates whether the RootView parameter is a "Name" or "ID". This parameter determines how the script interprets the RootView input.
- **Default**: Name
- **Options**: 
  - "Name" - Use when providing a view name (e.g., "My View")
  - "ID" - Use when providing a view ID (e.g., "123")

### RecursionLevel
- **Type**: Number (string, parsed as integer)
- **Description**: The level of recursion for retrieving subviews. Specifying '1' shows direct subviews, '2' goes one level deeper, and so on. If not specified or invalid, the script defaults to 1.
- **Default**: 1

## Project Type

**Automation Script** - This is a standard DataMiner Automation script as indicated by the DMSScript XML file structure.

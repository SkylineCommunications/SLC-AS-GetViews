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

## Use Cases

### Unknown View Handling
If you specify a view that doesn't exist in the DataMiner system:
- **By Name**: The script will throw an exception and exit with a failure message: "Failed to retrieve view: {exception message}. Please verify the view name/ID exists and try again."
- **By ID**: The script will throw an exception and exit with the same failure message.

### Invalid Input Handling
- **Invalid ID format**: If RootViewInputType is set to "ID" but RootView contains non-numeric characters, the script exits with: "Invalid View ID: '{input}'. Please provide a numeric ID (e.g., 123)."
- **Empty RootView**: If no RootView is provided, the script exits with: "RootView parameter is required. Please provide a view name or ID."
- **Mismatched input type**: If you provide an ID but set RootViewInputType to "Name", the script will attempt to find a view with that ID as its name. If no view has that name, it will fail with the view not found error. The same applies in reverse - providing a name with RootViewInputType set to "ID" will fail with an invalid ID format error.

**Recommendation**: Ensure that the provided view name or ID exists in your DataMiner system and that the RootViewInputType matches your input format. You can verify view names and IDs through the DataMiner Surveyor or other management tools.

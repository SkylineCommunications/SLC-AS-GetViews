# SLC-AS-GetViews

This script will ask for three script parameters:

- RootView: Name or ID of the view for which the subviews will be returned.
- RootViewInputType: Indicates whether the RootView parameter is a "Name" or "ID". (Default: Name)
- RecursionLevel: The level of recursion for retrieving subviews (number). Specifying '1' shows direct subviews, '2' goes one level deeper, etc. Defaults to 1 if not specified or invalid.

## Logic

The script will log in information events a list of views that are under the specified root view, up to the specified recursion level. The name and ID of each view are logged with indentation to show the hierarchy level.

The script supports both view names and view IDs as input. Use the RootViewInputType parameter to specify which type of input you are providing:
- Set to "Name" to use a view name (e.g., "My View")
- Set to "ID" to use a view ID (e.g., "123")

## Future Implementation Ideas

Go to the 'Issues' tab to find out the limitations and future enhancements of this script.

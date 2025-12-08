# SLC-AS-GetViews

This script will ask for two script parameters:

- RootView: Name or ID of the view for which the subviews will be returned.
- RootViewInputType: Indicates whether the RootView parameter is a "Name" or "ID". (Default: Name)

## Logic

The script will log in information events a list of views that are directly under the specified root view. The name and ID of the view are logged.

The script supports both view names and view IDs as input. Use the RootViewInputType parameter to specify which type of input you are providing:
- Set to "Name" to use a view name (e.g., "My View")
- Set to "ID" to use a view ID (e.g., "123")

## Future Implementation Ideas

Go to the 'Issues' tab to find out the limitations and future enhancements of this script.

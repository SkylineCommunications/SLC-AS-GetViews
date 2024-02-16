# SLC-AS-GetViews

This script will ask for one script parameter:

- RootView: Name of the view for which the subviews will be returned.

## Logic

The script will log in information events a list of views that are directly under the specified root view. The name and ID of the view are logged.

## Future Implementation Ideas

- The script should allow extra input to indicate what level of recursion you would like. The options could be specified by a number, indicating the level of recursion.
Specifying number '1' would show the direct sub views, while '2' would go one level deeper in the tree.

- Possibility to indicate if you want to specify the root view by name or by ID in the script parameters.

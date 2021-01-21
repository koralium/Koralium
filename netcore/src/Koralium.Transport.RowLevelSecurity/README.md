# Transport for Row level security

This transport library allows a caller to get what filters should be applied to a dataset, given a specific user.
This is useful if the data is cached elsewhere, for instance in an aggregated form, but still being able to
apply the same row level security as the data service.
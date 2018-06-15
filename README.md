# LocalOnlyAccessTest

This sample appplication contains a controller which is only accessable when navigating from the local machine. All outside access is denied. No additional authorization is required.

To accompllish this, a LocalOnlyAthorizationAttribute is created which checks if the request is from the local machine. To test this in action a YoMamaController is created using this attribute.

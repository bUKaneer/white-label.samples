# White Label Samples

This is a collection of experiments preserved here for reference.

Each folder represents a separate experiment for demonstration and reference purposes.

To setup each sample you'll need to enter the `PackagesAndContainers` folder 
for the sample in which you're interested and run  `docker compose up --detach` to start the local dockerised services.

Then run the `.\PushAllPackages.ps1` and `.\PublishAllContainers.ps1` scripts to initialise the environment.

The sample/project can then be run using the relative `Aspire\AppHost` project.

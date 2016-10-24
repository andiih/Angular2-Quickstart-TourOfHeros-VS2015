# Angular Quickstart and Tour Of Heroes

## AngularQuickstart
The Angular Quickstart project contains files from working theough the (rather simple) AngularQuickstart project found at <a href="https://angular.io/docs/ts/latest/quickstart.html">QuickStart</a>
However, this is setup to run in Visual Studio 2015, steps taken from <a href="https://angular.io/docs/ts/latest/cookbook/visual-studio-2015.html">Visual Studio 2015 QUickStart</a>

##TourOfHeroes
As the AngularQuickstart, this project contains the setup from the VS2015QS and the code from the end of the <a href="https://angular.io/docs/ts/latest/tutorial/toh-pt6.html">TourOfHeroes</a> quickstart. 
However, this project has been taken a tiny bit futher. The in-memory-data.service has been taken out of circuit, and a simple webapi2 controller used to supply real data. Web.config has had a couple of redirect rules added to allow HTLM5 routes to work, without breaking webapi calls.

##Not solved
What this currently doesn't solve is the question of what files to include in the project to allow it to be MSDeployed. 
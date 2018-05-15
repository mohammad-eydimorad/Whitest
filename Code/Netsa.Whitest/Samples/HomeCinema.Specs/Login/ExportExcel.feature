Feature: Users can export reports in excel formati


@UI
Scenario: Excel Report
	Given I am viewing following records as search result :
	| Field1 | Field2 | Field3 |
	| X1      | Y1      | Z1      |
	| X2      | Y2      | Z2      |
	| X3      | Y3      | Z3      |
	When I request for export to excel
	Then I should be given an excel file matching the data
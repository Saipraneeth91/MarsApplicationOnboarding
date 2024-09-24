Feature: Skills

As a User i Should be able to maintain my skills in my profile  
so that who ever is interested in learning can contact me based on my Skills
@Skills
Scenario Outline: 1 Add Skills and Skill level for user profile
	Given User Login to the Application and navigates to Skill section
	When User tries to add <Skill> and <level> 
	Then <Skill> and <level> should be added succesfully

	Examples: 
	| Skill  | level |
	| 'Java'| 'Beginner'|  
	| 'Selenium'| 'Intermediate'|  
	| 'Postman'| 'Expert'|  

	Scenario Outline: 2  Add Skill record with already existing data
	Given  User Login to the Application and navigates to Skill section
	When User tries to add new  <newSkill> and <newlevel> for already existing <Skill> and <level>
	Then  User should get an error This Skill is already exist in your Skill list.

	Examples: 
	| Skill | level | newSkill | newlevel |
	| 'Java'  | 'Beginner'| 'Java'  | 'Beginner' |


 Scenario Outline: 3 Add Skill record with invalid Skill and valid Skill level
	Given  User Login to the Application and navigates to Skill section
	When User tries to add a new record with invalid <Skill> and valid <level>
	Then User should get an error Please enter Skill and level 

	Examples: 
	| Skill | level |
	|    '' | 'Expert' |
	
 Scenario Outline: 4 Add Skill record with valid Skill and invalid Skill level
	Given User Login to the Application and navigates to Skill section
	When User tries to add a new record with valid data <Skill> and invalid <level>
	Then User should get an error Please enter Skill and level 
	Examples: 
	| Skill | level |
	|'Jmeter'|    '' |

 Scenario Outline: 5 Add Skill record with invalid Skill and invalid Skill level
	Given User Login to the Application and navigates to Skill section
	When User tries to add a new record with invalid <Skill> and invalid <level>
	Then  User should get an error Please enter Skill and level 
	Examples: 
	| Skill | level |
	|    '' |    '' |

 Scenario Outline: 6 Add Skill record with Skill of extreme long input
	Given  User Login to the Application and navigates to Skill section
	When User tries to add a new record with extreme long<Skill> and valid <level>
	Then <Skill> record should not be added to profile
	Examples: 
	| Skill | level |
	|'TestcasepreparationtestdatamanagementcoordinationForeignExchangestSITe2eUATcommunicationtestautomationSQLISTQBrequirementsanalysistestplanningSystemtestingintegrationtestingdefecttrackingtestmetricsKYCAMLScrumJIRAbbackendtestingAPItestingSeleniumSpecFlowBDDCapitalMarketsBFSIBanking'|'Beginner' |

	Scenario Outline: 7 Edit Skills and Skill level
	Given  User Login to the Application and navigates to Skill section
	When   User edits the record of <Skill> and <level> to <newSkill> and <newlevel>
	Then   User Should be able to update profile with new updated <newSkill> and <newlevel> values

	Examples: 
	| Skill | level | newSkill | newlevel |
	| 'Java'  | 'Beginner' | 'C'   | 'Expert' |
	
	Scenario:8 Edit Skill record without changing existing Skill and Skill level
	Given  User is logged in and navigates to Skill section
	When User tries to update an existing record without editing <Skill> or <level> to <newSkill> and <newlevel>
	Then  User should get an error This Skill is already added to your Skill list.
	Examples: 
	| Skill | level | newSkill | newlevel |
	| 'Python'  | 'Beginner'| 'Python'| 'Beginner' |

	Scenario:9 Edit Skill record with blank Skill 
	Given  User is logged in and navigates to Skill section
	When User tries to update an existing record <Skill> <level> with blank <newSkill> <newlevel>
	Then User should get an error Please enter Skill and level 

	Examples: 
	| Skill | level | newSkill | newlevel |
	| 'C'  | 'Beginner'       | ''   | 'Skill Level' |


	Scenario: 10 Edit Skill record with blank level 
	Given  User is logged in and navigates to Skill section
	When User tries to update an existing record <Skill> <level> with  <newSkill> and blank <newlevel>
	Then User should get an error Please enter Skill and level 
	Examples: 
	| Skill | level | newSkill | newlevel |
	| 'SQL'  | 'Beginner'       | 'NOSQL'   | 'Skill Level' |

 Scenario Outline: 11  Edit Skill record with Skill of extreme long binary input
	Given  User is logged in and navigates to Skill section
	When User tries to update an existing record of <Skill> <level> with new record with extreme long binary input <newSkill> and <newlevel>
	Then Skill record should not be edited with <newSkill>
	Examples: 
	| Skill  | level | newSkill | newlevel |
	| 'English' | 'Expert'|'0100100001100101011011000110110001101111001000010010000001101001011011110110110001100101011011000110110001101111001000010010000001101111011011010110010100100001001000000111010001101111001000000110000101101110011011110111010100100001001000000111000001101111011100100110110001100101001000000111010001101111001000000110010001101111011011100110100101101100001000000110110001100001011100100110110001100101011100100010000001110110011010010110111001100110011011110110110001100110011001010010000001101001011011110110110001100111011001000010000001110111011001010111001001111001001000000110100001100101011011000110110001101111001000000110110001101111001000000110110101100001011100100110010001100101011001'|'Baginner'|

	Scenario Outline:  Delete Existing Skills from User Profile
	Given   User is logged in and navigates to Skill section
	When    User tries to delete <Skill> <level> from profile
	Then    <Skill> Should be deleted from profile
	Examples: 
	| Skill    | level    |
	| 'Python' | 'Expert' |



Feature: Language

As a user, I need to manage my language details in my profile
so that I can perform actions such as add, edit, or delete my language records


Scenario Outline: 1 Add Languages and language level for user profile
	Given User Login to the Application and navigates to language section
	When User add <language> and <languagelevel> 
	Then <language> and <languagelevel> should be added succesfully

	Examples: 
	| language  | languagelevel      |
	| 'English' | 'Fluent'           |
	| 'Hindi'   | 'Conversational'   |
	| 'French'  | 'Basic'            |
	| 'Telugu'  | 'Native/Bilingual' |

	Scenario Outline: 2  Add Language record with already existing data
	Given   User Login to the Application and navigates to language section
	When User tries to add new record <newlanguage> and <newlanguagelevel> for already existing <language> and <languagelevel>
	Then  User should get an error This language is already exist in your language list.

	Examples: 
	| language | languagelevel | newlanguage | newlanguagelevel |
	| 'Hindi'  | 'Basic'       | 'Hindi'   | 'Basic' |


 Scenario Outline: 3 Add Language record with invalid language and valid language level
	Given  User Login to the Application and navigates to language section
	When User tries to add new record with invalid <language> and valid <languagelevel>
	Then User should get an error Please enter language and level 

	Examples: 
	| language | languagelevel |
	|    ''      | 'Conversational' |
	
 Scenario Outline: 4 Add Language record with valid language and invalid language level
	Given User Login to the Application and navigates to language section
	When User tries to add new record with valid data <language> and invalid <languagelevel>
	Then User should get an error Please enter language and level 
	Examples: 
	| language | languagelevel |
	|    'French'      |    '' |

 Scenario Outline: 5 Add Language record with invalid language and invalid language level
	Given User Login to the Application and navigates to language section
	When User tries to add new record with invalid <language> and invalid <languagelevel>
	Then  User should get an error Please enter language and level 
	Examples: 
	| language | languagelevel |
	|    ''      |    ''          |

 Scenario Outline: 6 Add Language record with language of extreme long input
	Given  User Login to the Application and navigates to language section
	When User tries to add new record with extreme long<language> and valid <languagelevel>
	Then <language> record should not be added
	Examples: 
	| language | languagelevel |
	|'EnglishHindiTeluguSpanishFrenchGermanItalianChineseArabicRussianJapaneseKoreanPortugueseDutchSwedishNorwegianDanishFinnishPolishTurkishGreekHebrewThaiVietnameseIndonesianMalayBengaliPunjabiUrduSwahiliZuluXhosaCzechHungarianRomanianBulgarianSerbianCroatianSlovakUkrainianLithuanianLatvianEstonianCatalanBasqueGalicianWelshIrishScottish'|'Basic' |

	Scenario Outline: 7 Edit Languages and Language level
	Given  User Login to the Application and navigates to language section
	When   User edits the record with <language> and <languagelevel> to <newlanguage> and <newlanguagelevel>
	Then   User Should be able to update profile with modified <newlanguage> and <newlanguagelevel> values

	Examples: 
	| language | languagelevel | newlanguage | newlanguagelevel |
	| 'Hindi'  | 'Basic'       | 'English'   | 'Conversational' |
	
	Scenario:8 Edit Language record without changing existing language and language level
	Given  User is logged in and navigates to profile
	When User tries to update existing record without editing <language> or <languagelevel> to <newlanguage> and <newlanguagelevel>
	Then  User should get an error This language is already added to your language list.
	Examples: 
	| language | languagelevel | newlanguage | newlanguagelevel |
	| 'Hindi'  | 'Basic'       | 'Hindi'   | 'Basic' |

	Scenario:9 Edit Language record with blank language 
	Given  User is logged in and navigates to profile
	When User tries to update existing record <language> <languagelevel> with blank <newlanguage> <newlanguagelevel>
	Then User should get an error Please enter language and level 

	Examples: 
	| language | languagelevel | newlanguage | newlanguagelevel |
	| 'Telugu'  | 'Basic'       | ''   | 'Language Level' |


	Scenario: 10 Edit Language record with blank languagelevel 
	Given  User is logged in and navigates to profile
	When User tries to update existing record <language> <languagelevel> with  <newlanguage> and blank <newlanguagelevel>
	Then User should get an error Please enter language and level 
	Examples: 
	| language | languagelevel | newlanguage | newlanguagelevel |
	| 'Hindi'  | 'Basic'       | 'Telugu'   | 'Language Level' |

 Scenario Outline: 11  Edit Language record with language of extreme long binary input
	Given  User is logged in and navigates to profile
	When User tries to update existing record of <language> <languagelevel> with new record with extreme long binary input <newlanguage> and <newlanguagelevel>
	Then language record should not be edited with <newlanguage>
	Examples: 
	| language  | languagelevel | newlanguage | newlanguagelevel |
	| 'English' | 'Fluent'      |'0100100001100101011011000110110001101111001000010010000001101001011011110110110001100101011011000110110001101111001000010010000001101111011011010110010100100001001000000111010001101111001000000110000101101110011011110111010100100001001000000111000001101111011100100110110001100101001000000111010001101111001000000110010001101111011011100110100101101100001000000110110001100001011100100110110001100101011100100010000001110110011010010110111001100110011011110110110001100110011001010010000001101001011011110110110001100111011001000010000001110111011001010111001001111001001000000110100001100101011011000110110001101111001000000110110001101111001000000110110101100001011100100110010001100101011001'| 'Fluent'|

	Scenario Outline:  Delete Existing Languages from User Profile
	Given   User is logged in and navigates to delete section
	When    User deletes <language> and <level> from profile
	Then    <language> Should be deleted
	Examples: 
	| language  | level    |
	| 'English' | 'Fluent' |



	



	
	
	







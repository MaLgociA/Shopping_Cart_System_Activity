This project was made and continued only by Ocampo, Mark Patrick D. and will hereby serve as the Quiz #2 & #3 requirement as one of the partial fulfillments for the course subject Computer Programming 2. The program only used C# as its main programming language for the whole re-creation and modification of the system of the project as per advised and taught  by our professor. The changes and progress of the code would evidently be seen in the commits that was made here in GitHub, specifically here in the second branch entitled as "Quiz-Part-2".

Every requirements from the Quiz-Part-2 PDF file, as well as the comments from my repository were all taken into consideration as I re-create and modify the system. Hence, they were able to be fixed in this modified version.

(Note: MaLgociA and mxrkpxtrxckocmpx are both an account of Mr. Ocampo. I created the MaLgociA GitHub account as of April 10, 2026 using my imatmcuuu01@gmail.com gmail account. Due to negligence, I didn't know and notice that my GitHub has its auto-sync, on, so the moment I created this project, the accounts: MaLgociA and mxrkpxtrxckocmpx synced together as contributors of this project. But then again, both accounts belongs and only has access to me, Ocampo, Mark Patrick D.)

**SUMMARY OF THE CHANGES MADE:**

The program comprises, displays, and added the following features:

**• VIEW PRODUCTS**
- This feature displays displays a list of all available items in the system, including their Product ID, Names, Prices, Stocks, and Categories. It allows users to browse products and serves as the entry point for selecting items that they can then add to their cart in a separate step.

**• SEARCH PRODUCT**
- This feature allows the user to search a particular product availabe in the system. Just type the name of the product you desire to see, it would automatically display all the details you'd need to know for buying it. Capitalization is also not important.

**• FILTER BY CATEGORY**
- This feature is almost the same as the "Search Product" feature however, the only key difference is that it allows the user to view only the products that belong to a specific category they choose. It scans through the product list and displays matching items, making it easier for users to browse and find products based on type instead of viewing all available items.
  
**• MANAGE CART**
- This feature allows the user to review and modify the items they’ve selected before checkout. It provides options to remove items, update quantities, back from the main menu, or even clear the entire cart, while automatically adjusting product stock based on those changes. This feature ensures the cart accurately reflects the user’s intended purchase before finalizing the transaction.
  
**• CHECKOUT**
- This feature finalizes the purchase by calculating the total cost of items in the cart, applying the 10% discount if total bought products exceeds PHP 5000, and processing the user’s payment. It generates a receipt with transaction details, records the order in the system, and updates inventory while displaying any low stock alerts after the transaction.

**• VIEW ORDER HISTORY**
- This feature displays a list of all successfully completed transactions. It shows each order’s receipt number and final total, allowing users to review their past purchases in chronological order. All transactions will be recorded within every one run of the code. If the terminal is killed or has been stopped, it would all repeat and record the new transactions of that new run of the program.
  
**• ADD STOCK**
- This feature allows the user to manually increase the available quantity of a selected product in the inventory. This feature helps manage restocking by manually updating product stock levels, ensuring items remain available for future purchases.

**• EXIT**
- This feature terminates or stops the program and closes the program safely. It allows the user to end their session in the system without performing any further actions or changes.


**"AI Usage in This Project"**

I used AI as a guide while building and improving my shopping cart system in C#. It helped me organize my code better by separating features like cart management, checkout, and order history. I also used it to understand and fix issues/errors in my program flow, especially with loops and control statements like break and continue. It supported me in adding features such as stock management and improving input validation for a smoother user experience. Lastly, it helped me refine the output, including proper formatting of prices with the peso sign.

**Prompts/Questions I asked:**

• "How to make another branch in GitHub, provided that I would still use my VSCode?"

• "Would my second branch alter the main branch as I edit and make changes in my second branch?"

• "How can I design and structure a console-based shopping cart system using arrays and control flow in C#?"

• "How can I properly manage cart operations: add, remove, update, back, and clear while ensuring stock is accurately updated in real time?"

• "How can I store completed transactions efficiently and display them as an organized order history?"

• "Does my Y/N validation strictly prohibits other characters or numbers that would be typed on it?"

**Changes made after using AI:**

• Gained a clearer understanding of control flow, especially how break and continue affect loop execution.

• Learned how arrays can be used to store and manage multiple data types in a simple console-based system, such as products, cart items, and order history.

• Added an up-to-date time and date to the receipt of when a specific transaction has happened.

• Gained another experience in using loops to iterate through arrays for searching, displaying, and updating values efficiently.

• Learned how to make Y/N validation more secured and prohibited by other inputs.

• Improved stock management by properly handling deduction, restoration, and manual addition of product stock.





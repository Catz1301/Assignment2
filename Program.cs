using System;

namespace Assignment2 {
	class Program {
		static void Main(string[] args) {
			bool metric = false;
			Console.WriteLine("Welcome to the Body Mass Index Calculator!");
			string measureSystem = ask("Are you using Metric or Imperial measurements? (m/I): ");
			if (measureSystem.ToLower().Equals("m")) {
				metric = true;
			}

			if (metric) {
				double weight = double.NaN;
				double height = double.NaN;
				while (double.IsNaN(weight)) {
					try {
						weight = double.Parse(ask("Please enter your weight, in kilograms: "));

					} catch (Exception e) when (e is ArgumentNullException || e is FormatException || e is OverflowException) {
						if (e is FormatException) {
							Console.WriteLine("You must enter a number, nothing else. Goodbye!");
						} else if (e is ArgumentNullException) {
							Console.WriteLine("I'm not Garfield's scale, I won't insult you. Enter your weight.");
						}
					}
				}

				while (double.IsNaN(height)) {
					try {
						height = double.Parse(ask("Please enter your height, in metres: "));
					} catch (Exception e) when (e is ArgumentNullException || e is FormatException || e is OverflowException) {
						if (e is FormatException) {
							Console.WriteLine("You must enter a number, nothing else. Goodbye!");
						} else if (e is ArgumentNullException) {
							Console.WriteLine("Don't be embarrassed, enter your height.");
						} else if (e is OverflowException) {
							Console.WriteLine("Something went wrong, try again.");
						}
					}
				}
				double BMI = (weight)/(height*height);
				output(BMI);
			} else {
				double weight = double.NaN;
				double height = double.NaN;
				while (double.IsNaN(weight)) {
					try {
						weight = double.Parse(ask("Please enter your weight, in pounds: "));

					} catch (Exception e) when (e is ArgumentNullException || e is FormatException || e is OverflowException) {
						if (e is FormatException) {
							Console.WriteLine("You must enter a number, nothing else. Goodbye!");
						} else if (e is ArgumentNullException) {
							Console.WriteLine("I'm not Garfield's scale, I won't insult you. Enter your weight.");
						}
					}
				}

				while (double.IsNaN(height)) {
					try {
						height = double.Parse(ask("Please enter your height, in inches: "));
					} catch (Exception e) when (e is ArgumentNullException || e is FormatException || e is OverflowException) {
						if (e is FormatException) {
							Console.WriteLine("You must enter a number, nothing else. Goodbye!");
						} else if (e is ArgumentNullException) {
							Console.WriteLine("Don't be embarrassed, enter your height.");
						} else if (e is OverflowException) {
							Console.WriteLine("Something went wrong, try again.");
						}
					}
				}
				double BMI = (weight*703) / (height * height);
				output(BMI);
			}
		}

		static string ask(string prompt) {
			Console.Write(prompt);
			return Console.ReadLine();
		}

		static void output(double bodyMassIndex) {
			Console.WriteLine("Your body mass index is {0:N}\r\n" +
				"Important body mass index values: \r\n" +
				"Underweight: less than 18.5\r\n" +
				"Normal:      between 18.5 and 24.9\r\n" +
				"Overweight:  between 25 and 29.9\r\n" +
				"Obese:       30 or greater.\n", bodyMassIndex);
		}
	}
}

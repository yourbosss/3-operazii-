using System;

namespace labaThree {
    public class MatrixCalculator {

        private static MatrixCalculator instance;

        private MatrixCalculator() {

        }

        public static MatrixCalculator GetInstance {

            get {

                if (instance == null) {

                    instance = new MatrixCalculator();
                }

                return instance;
            }
        }

        private SquareMatrixClone CreateSquareMatrix() {

            var notSet = true;

            Console.WriteLine("Enter matrix name: ");
            var name = Console.ReadLine();

            Console.WriteLine("\n");
            Console.WriteLine("Generate random matrix?\n");
            Console.WriteLine("no         0");
            Console.WriteLine("yes        1");

            while (notSet) {

                switch (Console.ReadLine()) {

                    case "0":
                        notSet = false;
                        break;
                    case "1":
                        return new SquareMatrixClone(name);
                    default:
                        Console.WriteLine("Incorrect option. Try again.");
                        break;
                }
            }

            notSet = true;

            var size = 0;

            while (notSet) {

                Console.WriteLine("\n");
                Console.WriteLine("Enter matrix size: ");

                if (!int.TryParse(Console.ReadLine(), out size) || size <= 1) {

                    Console.WriteLine("Incorrect value. Try again.");
                }
                else {

                    notSet = false;
                }
            }

            notSet = true;

            Console.WriteLine("\n");
            Console.WriteLine("Generate random elements?\n");
            Console.WriteLine("no         0");
            Console.WriteLine("yes        1");

            while (notSet) {

                switch (Console.ReadLine()) {

                    case "0":
                        notSet = false;
                        break;
                    case "1":
                        return new SquareMatrixClone(size, name);
                    default:
                        Console.WriteLine("Incorrect option. Try again.");
                        break;
                }
            }

            notSet = true;

            var elements = new double[size, size];
            double currentElement;
            for (var rowIndex = 0; rowIndex < size; ++rowIndex) {

                for (var columnIndex = 0; columnIndex < size; ++columnIndex) {

                    while (notSet) {

                        Console.WriteLine($"Enter element {rowIndex}{columnIndex}: ");

                        if (!double.TryParse(Console.ReadLine(), out currentElement)) {

                            Console.WriteLine("Incorrect value. Try again.");
                        }
                        else {

                            elements[rowIndex, columnIndex] = currentElement;

                            notSet = false;
                        }
                    }

                    notSet = true;
                }
            }

            return new SquareMatrixClone(size, name, elements);
        }

        private void GetMatrixInfo(SquareMatrixClone matrix) {

            Console.WriteLine($"Matrix {matrix.Name}");
            Console.WriteLine($"Determinant: {matrix.Determinant()}");
            Console.WriteLine($"Hash code: {matrix.GetHashCode()}");
            Console.WriteLine($"Sum of elements: {matrix.SumOfElements()}");
            Console.WriteLine($"As string: {matrix}");
        }

        private string Comparison(SquareMatrixClone left, SquareMatrixClone right) {

            if (left > right) {

                return $"{left.Name} > {right.Name}";
            }
            else if (left < right) {

                return $"{left.Name} < {right.Name}";
            }
            else {

                return $"{left.Name} = {right.Name}";
            }
        }

        public void Calculator() {

            Console.WriteLine("Create 1st matrix:\n");
            var left = CreateSquareMatrix();

            Console.Clear();

            Console.WriteLine("Create 2st matrix:\n");
            var right = CreateSquareMatrix();

            Console.Clear();

            left.PrintMatrix();
            Console.WriteLine("\n");
            right.PrintMatrix();
            Console.WriteLine("\n");

            Console.WriteLine("add           0");
            Console.WriteLine("substract     1");
            Console.WriteLine("multiply      2");
            Console.WriteLine("compare       3");
            Console.WriteLine("info          4");
            Console.WriteLine("transpose     5");
            Console.WriteLine("EXIT          6");

            var option = true;

            while (true) {
                while (option) {

                    Console.WriteLine("\n");
                    Console.WriteLine("Choose option");

                    switch (Console.ReadLine()) {

                        case "0":
                            try {
                                var result = (SquareMatrix)left.Clone();
                                result += right;

                                result.PrintMatrix();
                            }
                            catch (SquareMatrixSizeException exception) {
                                Console.WriteLine(exception.Message);

                                break;
                            }

                            option = false;
                            break;
                        case "1":
                            try {
                                var result = (SquareMatrix)left.Clone();
                                result -= right;

                                result.PrintMatrix();
                            }
                            catch (SquareMatrixSizeException exception) {
                                Console.WriteLine(exception.Message);

                                break;
                            }

                            option = false;
                            break;
                        case "2":
                            try {
                                var result = (SquareMatrix)left.Clone();
                                result *= right;

                                result.PrintMatrix();
                            }
                            catch (SquareMatrixSizeException exception) {
                                Console.WriteLine(exception.Message);

                                break;
                            }

                            option = false;
                            break;
                        case "3":
                            Console.WriteLine(Comparison(left, right));

                            option = false;
                            break;
                        case "4":
                            Console.WriteLine("\n");
                            GetMatrixInfo(left);
                            Console.WriteLine();
                            GetMatrixInfo(right);

                            option = false;
                            break;
                        case "5":
                            var tMatrix = (SquareMatrix)left.Clone();
                            tMatrix = tMatrix.Transpose();
                            tMatrix.PrintMatrix();

                            tMatrix = (SquareMatrix)right.Clone();
                            tMatrix = tMatrix.Transpose();
                            tMatrix.PrintMatrix();

                            option = false;
                            break;
                        case "6":
                            return;
                        default:
                            Console.WriteLine("Incorrect option. Try again.");
                            break;
                    }

                    option = true;
                }
            }
        }
    }
}
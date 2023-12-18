#include <iostream>
#include <thread>
#include <chrono>
#include <limits>


class RiceCooker {
public:
    static const int COOKING_TIME = 3; // in seconds
    bool cooked_rice;

    RiceCooker() : cooked_rice(false) {}

    void add_rice(int amount) {
        std::cout << "Adding " << amount << " cups of rice to the rice cooker." << std::endl;
    }

    void add_water(int /* amount */) {
        std::cout << "Adding water to the rice cooker." << std::endl;
    }

    void cook() {
        if (cooked_rice) {
            std::cout << "Rice is already cooked. Reheat if needed." << std::endl;
        } else {
            std::cout << "Cooking the rice..." << std::endl;
            std::this_thread::sleep_for(std::chrono::seconds(COOKING_TIME));
            cooked_rice = true;
            std::cout << "Rice is cooked!" << std::endl;
        }
    }

    void serve() {
        if (cooked_rice) {
            std::cout << "Serving delicious rice!" << std::endl;
            cooked_rice = false;
        } else {
            std::cout << "No rice cooked. Please cook first." << std::endl;
        }
    }
};

void menu_add_rice(RiceCooker& rice_cooker) {
    int amount;
    std::cout << "Enter the amount of rice to add (in cups): ";
    std::cin >> amount;
    if (std::cin.fail()) {
        std::cin.clear();
        std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
        throw std::invalid_argument("Invalid input. Please enter a valid number.");
    }

    if (amount > 0) {
        rice_cooker.add_rice(amount);
        std::cout << "Rice added successfully!" << std::endl;
    } else {
        throw std::invalid_argument("Invalid amount. Please enter a positive number.");
    }
}

void menu_add_water(RiceCooker& rice_cooker) {
    rice_cooker.add_water(0);
}

void menu_cook(RiceCooker& rice_cooker) {
    rice_cooker.cook();
}

void menu_serve(RiceCooker& rice_cooker) {
    rice_cooker.serve();
}

void display_menu() {
    std::cout << "\nRice Cooker Menu:" << std::endl;
    std::cout << "1. Add rice" << std::endl;
    std::cout << "2. Add water" << std::endl;
    std::cout << "3. Cook" << std::endl;
    std::cout << "4. Serve" << std::endl;
    std::cout << "5. Exit" << std::endl;
}

int user_choice() {
    int choice;
    std::cout << "Choose an option: ";
    std::cin >> choice;
    if (std::cin.fail()) {
        std::cin.clear();
        std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
        throw std::invalid_argument("Invalid input. Please enter a valid number.");
    }
    return choice;
}

void process_user_choice(int choice, RiceCooker& rice_cooker) {
    try {
        switch (choice) {
            case 1: menu_add_rice(rice_cooker); break;
            case 2: menu_add_water(rice_cooker); break;
            case 3: menu_cook(rice_cooker); break;
            case 4: menu_serve(rice_cooker); break;
            case 5:
                std::cout << "Exiting the rice cooker. Goodbye!" << std::endl;
                break;
            default:
                throw std::invalid_argument("Invalid choice. Please choose a valid option.");
        }
    } catch (const std::exception& e) {
        std::cerr << "Error: " << e.what() << std::endl;
    }
}

int main() {
    RiceCooker rice_cooker;

    while (true) {
        try {
            display_menu();
            int choice = user_choice();
            process_user_choice(choice, rice_cooker);
            if (choice == 5) {
                break;
            }

            std::cout << "Press Enter to see the menu again." << std::endl;
            std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
            std::cin.get();
        } catch (const std::exception& e) {
            std::cerr << "Error: " << e.what() << std::endl;
        }
    }

    return 0;
}

#include <iostream>
#include <cassert>

class RiceCooker {
public:
    static const int COOKING_TIME = 3; // in seconds
    bool cooked_rice;

    RiceCooker() : cooked_rice(false) {}

    void cook() {
        if (cooked_rice) {
            std::cout << "Rice is already cooked. Reheat if needed." << std::endl;
        } else {
            std::cout << "Cooking the rice..." << std::endl;
            // Simulate cooking time
            std::this_thread::sleep_for(std::chrono::seconds(COOKING_TIME));
            cooked_rice = true;
            std::cout << "Rice is cooked!" << std::endl;
        }
    }
};

// Simple unit test for the RiceCooker class
void testRiceCookerCook() {
    RiceCooker rice_cooker;

    // Before cooking, rice should not be cooked
    assert(!rice_cooker.cooked_rice);

    // Cook the rice
    rice_cooker.cook();

    // After cooking, rice should be cooked
    assert(rice_cooker.cooked_rice);
}

int main() {
    // Run the simple unit test
    testRiceCookerCook();

    std::cout << "Simple unit test passed!" << std::endl;

    return 0;
}

package main

import (
  "bytes"
  "io"
  "os"
  "testing"
  "time"
  
)

func TestRiceCooker(t *testing.T) {
  // Create a new RiceCooker
  riceCooker := RiceCooker{}

  // Test AddRice method
  t.Run("AddRice", func(t *testing.T) {
    expectedOutput := "Adding 2 cups of rice to the rice cooker.\n"
    addRiceOutput := captureOutput(func() {
      riceCooker.AddRice(2)
    })
    if addRiceOutput != expectedOutput {
      t.Errorf("AddRice output is incorrect. Expected:\n%s\nGot:\n%s", expectedOutput, addRiceOutput)
    }
  })

  // Test AddWater method
  t.Run("AddWater", func(t *testing.T) {
    expectedOutput := "Adding water to the rice cooker.\n"
    addWaterOutput := captureOutput(func() {
      riceCooker.AddWater()
    })
    if addWaterOutput != expectedOutput {
      t.Errorf("AddWater output is incorrect. Expected:\n%s\nGot:\n%s", expectedOutput, addWaterOutput)
    }
  })

  // Test Cook method
  t.Run("Cook", func(t *testing.T) {
    expectedCookOutput := "Cooking the rice...\nRice is cooked!\n"
    expectedReheatOutput := "Rice is already cooked. Reheat if needed.\n"

    // First cook
    cookOutput := captureOutput(func() {
      riceCooker.Cook()
    })
    if cookOutput != expectedCookOutput {
      t.Errorf("Cook output is incorrect. Expected:\n%s\nGot:\n%s", expectedCookOutput, cookOutput)
    }

    // Attempt to cook again (reheat)
    reheatOutput := captureOutput(func() {
      riceCooker.Cook()
    })
    if reheatOutput != expectedReheatOutput {
      t.Errorf("Reheat output is incorrect. Expected:\n%s\nGot:\n%s", expectedReheatOutput, reheatOutput)
    }

    // Wait for cooking time
    time.Sleep(3 * time.Second)

    // Cook again after waiting
    secondCookOutput := captureOutput(func() {
      riceCooker.Cook()
    })
    if secondCookOutput != expectedCookOutput {
      t.Errorf("Second cook output is incorrect. Expected:\n%s\nGot:\n%s", expectedCookOutput, secondCookOutput)
    }
  })

  // Test Serve method
  t.Run("Serve", func(t *testing.T) {
    expectedServeOutput := "Serving delicious rice!\n"
    expectedNoServeOutput := "No rice cooked. Please cook first.\n"

    // Serve when rice is cooked
    serveOutput := captureOutput(func() {
      riceCooker.Serve()
    })
    if serveOutput != expectedServeOutput {
      t.Errorf("Serve output is incorrect. Expected:\n%s\nGot:\n%s", expectedServeOutput, serveOutput)
    }

    // Serve when no rice is cooked
    riceCooker.CookedRice = false
    noServeOutput := captureOutput(func() {
      riceCooker.Serve()
    })
    if noServeOutput != expectedNoServeOutput {
      t.Errorf("NoServe output is incorrect. Expected:\n%s\nGot:\n%s", expectedNoServeOutput, noServeOutput)
    }
  })
}

// Helper function to capture standard output
func captureOutput(f func()) string {
  old := os.Stdout
  r, w, _ := os.Pipe()
  os.Stdout = w
  defer func() {
    os.Stdout = old
  }()
  defer w.Close()
  defer r.Close()

  f()

  var buf bytes.Buffer
  io.Copy(&buf, r)
  return buf.String()
}

# C# Thread Synchronization

concise examples of how to use various thread synchronization primitives in C# to ensure thread safety and manage concurrent access to shared resources.

Absolutely, here's a draft of a README file for your repository, focusing on demonstrating `lock`, `Monitor`, `Semaphore`, and `Mutex` in C# with simple examples.

## Included Primitives

* **`lock`** - The most common and straightforward way to achieve mutual exclusion within a single process.
* **`Monitor`** - Offers more fine-grained control over locking and thread signaling compared to `lock`.
* **`Semaphore`** - Manages a pool of resources, allowing a limited number of threads to access them concurrently.
* **`Mutex`** - Provides mutual exclusion across multiple processes, ensuring that only one instance of an application or resource is accessed at a time.

## Examples

Each synchronization primitive has its dedicated folder with a C# console application demonstrating its usage:

* **`LockExample`:**
    * Shows how to use `lock` to protect a shared counter variable from race conditions in a multithreaded environment.

* **`MonitorExample`:**
    * Illustrates a classic producer-consumer scenario using `Monitor` to synchronize access to a shared queue and signal between threads.

* **`SemaphoreExample`:**
    * Simulates a limited resource pool (e.g., database connections) using `Semaphore` to control the number of concurrent accesses.

* **`MutexExample`:**
    * Demonstrates how to use `Mutex` to ensure that only one instance of an application is running at a time.

## Contributing

Feel free to contribute additional examples or improvements to existing ones. Please open an issue or pull request to discuss your proposed changes.

By providing clear examples and explanations, this repository will serve as a valuable resource for developers learning about thread synchronization in C#.
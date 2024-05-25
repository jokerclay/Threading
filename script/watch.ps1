# Define the interval for logging (in seconds)
$interval = 0.1  # Interval in seconds

# Start an infinite loop to continuously log process and thread information
while ($true) {
    try {
        # Get the process information for the process named 'threading'
        $process = Get-Process threading -ErrorAction Stop
        $threads = $process.Threads
        $timestamp = Get-Date

        # Print the current timestamp
        Write-Host "Timestamp: $timestamp"

        # Iterate through each thread in the process
        foreach ($thread in $threads) {
            # Construct a string with the thread details
            $threadInfo = "ThreadId: $($thread.Id), State: $($thread.ThreadState), StartTime: $($thread.StartTime)"
            
            # Print the thread details to the console
            Write-Host $threadInfo
        }
    } catch {
        # Print an error message if Get-Process fails
        # Write-Host "Failed to get process information: $_"
    }

    # Sleep for the specified interval before logging the next entry
    Start-Sleep -Seconds $interval
}

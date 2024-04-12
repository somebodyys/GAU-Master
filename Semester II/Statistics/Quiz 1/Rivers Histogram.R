
help("rivers")
hist(rivers,        # Change color of histogram
     col = "red")

boxplot(rivers)


boxplot(rivers)

hist(rivers,      # Change number of histogram breaks
     breaks = 50)
hist(rivers,  # Specify fixed breaks with different width
     breaks = c(0, 250, 300, 400, 500, 750, 1000, 2500, 5000))

# It is also possible to modify the width and height 
#of the Y- and X-axes 
#of our histogram by specifying the xlim and ylim options.

hist(rivers,        # Change axis limits of histogram
     xlim = c(0, 5000),
     ylim = c(0, 120))
# Example 7: Histogram with Overlaid Density Line
hist(rivers,                                                # Draw histogram with probability
     ylim = c(0, 0.002),
     prob = TRUE)
lines(density(rivers), col = "red")  

#Example 8: Histogram with Values on Top of Bars
hist_values <- hist(rivers)   # Store values of histogram
hist_values     # Print values to RStudio console
text(hist_values$mids,                                      # Add values of histogram on top of bars
     hist_values$counts,
     labels = hist_values$counts,
     adj = c(0.5, - 0.5))
hist_values = hist(mtcars$mpg)
hist_values
text(hist_values$mids,                                      # Add values of histogram on top of bars
     hist_values$counts,
     labels = hist_values$counts,
     adj = c(0.5, - 0.5))



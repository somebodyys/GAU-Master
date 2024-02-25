# Raw Data
data <- c(
  42, 28, 37, 45, 58, 41, 39, 52, 40, 34, 25, 43, 49, 45, 48, 42, 44, 44, 38, 41,
  41, 38, 37, 50, 40, 31, 50, 41, 46, 37, 40, 38, 26, 41, 41, 44, 22, 32, 35, 41,
  38, 47, 52, 48, 55, 41, 28, 26, 41, 44, 55, 36, 34, 48, 43, 46, 43, 42, 28, 41,
  38, 41, 65, 42, 46, 34, 38, 40, 39, 40, 39, 36, 25, 31, 40, 39, 38, 45, 70, 36,
  44, 39, 42, 44, 50, 46, 37, 60, 60, 47, 36, 73, 43, 46, 37, 46, 34, 29, 40, 37)


number_of_intervals = sqrt(length(data))
interval_size = round(( max(data) - min(data) ) / number_of_intervals)
intervals_start_point = floor(min(data) / interval_size) * interval_size

lower_bounds <- rev(seq(intervals_start_point, intervals_start_point + (interval_size * number_of_intervals), by = interval_size))
upper_bounds <- lower_bounds + (interval_size - 1)

real_bound_step = (lower_bounds[1] - upper_bounds[2] ) / 2

real_lower_bounds <- lower_bounds - real_bound_step
real_upper_bounds <- upper_bounds + real_bound_step

frequencies = rev(as.vector(unname(table(cut(data, breaks = c(lower_bounds, max(upper_bounds)), include.lowest = TRUE, right = FALSE)))))
rf = frequencies / length(data)
pf = frequencies / length(data) * 100
cf = rev(cumsum(rev(pf)))
crf = cf / 100
cpf = crf * 100

interval_data <- data.frame(
  Interval = paste(lower_bounds, upper_bounds, sep = "-"),
  RealMargins = paste(real_lower_bounds, real_upper_bounds, sep = "-"),
  MiddlePoint = (lower_bounds + upper_bounds) / 2,
  f = frequencies,
  rf = rf,
  pf = pf,
  cf = cf,
  crf = crf,
  cpf = cpf
)

x = 39
interval_including_x=subset(interval_data, x >= as.numeric(substring(interval_data$Interval, 1, 2)) & x <= as.numeric(substring(interval_data$Interval, 4, 6)))
fi = interval_including_x$f
xl = as.numeric(unlist(strsplit(interval_including_x$RealMargins, "-")))[1]
cfl = sum(subset(interval_data, as.numeric(substring(interval_data$RealMargins, 1, 4)) < xl)$f)
percentile_rank = (cfl + ((x - xl) / interval_size) * fi) / length(data) * 100

P = 0.51
percentile = xl + ((P * length(data) - cfl) / fi) * interval_size


# Initial Vector
data

# Frequency Table
interval_data

# Percentile Rank for number 39
percentile_rank

# Percentile for P = 0.51
percentile

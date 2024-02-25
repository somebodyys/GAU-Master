foo <- 5.5:0.5
foo
foo-c(2,4,6,8,10,12)

#

bar <- c(1,-1)
foo*bar

#

baz <- c(1,-1,0.5,-0.5)
foo*baz

#

qux <- 3
foo+qux

#

foo

#

sum(foo)

#

prod(foo)

#

foo
foo[c(1,3,5,6)] <- c(-99,99)
foo

A <- matrix(data=c(-3,2,893,0.17),nrow=2,ncol=2)
A
matrix(data=c(1,2,3,4,5,6),nrow=2,ncol=3,byrow=FALSE)

#

matrix(data=c(1,2,3,4,5,6),nrow=2,ncol=3,byrow=TRUE)


## 

rbind(1:3,4:6)

#

cbind(c(1,4),c(2,5),c(3,6))

#

mymat <- rbind(c(1,3,4),5:3,c(100,20,90),11:13)
mymat

dim(mymat)
nrow(mymat)
ncol(mymat)
dim(mymat)[2]



###############


A <- matrix(c(0.3,4.5,55.3,91,0.1,105.5,-4.2,8.2,27.9),nrow=3,ncol=3)
A
A[3,2]




A[,2]

#

A[1,]

#

A[2:3,]

A[,c(3,1)]

A[c(3,1),2:3]

#

diag(x=A)




A[,-2]

#

A[-1,3:2]

#

A[-1,-2]

#

A[-1,-c(2,3)]

#

B <- A
B

#

B[2,] <- 1:3
B

#

B[c(1,3),2] <- 900
B

#

B[,3] <- B[3,]
B

#

B[c(1,3),c(1,3)] <- c(-7,7)
B

#

B[c(1,3),2:1] <- c(65,-65,88,-88)
B

#

diag(x=B) <- rep(x=0,times=3)
B



###############



A <- rbind(c(2,5,2),c(6,1,4))
A
t(A)

#

t(t(A))




A <- diag(x=3)
A




A <- rbind(c(2,5,2),c(6,1,4))
a <- 2
a*A




A <- cbind(c(2,5,2),c(6,1,4))
A
B <- cbind(c(-2,3,6),c(8.1,8.2,-9.8))
B
A-B




A <- rbind(c(2,5,2),c(6,1,4))
dim(A)
B <- cbind(c(3,-1,1),c(-3,1,5))
dim(B)

#

A%*%B

#

B%*%A




A <- matrix(data=c(3,4,1,2),nrow=2,ncol=2)
A
solve(A)

#

A%*%solve(A)

#a
seq(from=5,to=-11,by=-0.3)
#b
seq(from=-11,to=5,by=0.3)
#c
foo<-rep(x=c(-1,3,-5,7,-9),times=2,each=10)
foo
length(foo)
sort(foo,decreasing=TRUE)
#d
#i
6:12
#ii
rep(x=5.3,times=4)
#iii
-3
#iv
a<-length(foo)
a
myseq<- seq(from=102,to=a,length.out=9)
myseq


#1
seq <- seq(from=5,to=-11,by=-0.3)
seq

#2
seq <- seq(from=-11,to=5,by=0.3)   #sort(seq,decreasing=FALSE)
seq

#3
v = sort(rep(x=c(-1,3,-5,7,-9),times=2,each=10),decreasing=TRUE)
v

#4
vec <- c(6:12,rep(5.3,times=3),-3,seq(from=102,to=length(v),length.out=9))
vec
length(vec)
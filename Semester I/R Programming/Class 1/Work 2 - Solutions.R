#i
myseq<- seq(from=3,to=6,length.out=5)
myseq
#ii
rep(x=c( 2,-5.1,-33),times=2)
#iii
7
42+2
#b
bar<-myseq[-c(1,5)]
bar
#c
foo<-myseq[c(1,5)]
foo
myvec<-c(foo[1],bar,foo[2])
myvec
myseq1<-sort(x=myseq)
myseq1
colon(myseq1)

#f
rep(x=myvec,times=3,each=2)
#(f)
foo[length(x=foo):1]
sort(x=foo,decreasing=TRUE)
#(g)
baz[c(rep(x=3,times=3),rep(x=6,times=4),length(x=baz))]
#(h)
qux <- foo
qux[c(1,5:7,12)] <- 99:95
qux


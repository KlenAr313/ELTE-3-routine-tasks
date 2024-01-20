#include <iostream>
#include "shifter.h"
#include <map>
#include <string>
#include <deque>
#include <vector>
#include "shifter.h"
#include <functional>


struct string_size_less
{

  bool operator()( const std::string& lhs,
                   const std::string& rhs ) const
  {
    return lhs.size() < rhs.size();
  }

};

const int max = 1024;

int main()
{
  int your_mark = 1;
  //2-es
  std::vector<int> vm;
  for( int i = 0; i < max; ++i )
  {
    vm.push_back( i );
  }
  std::string s = "Hello World!";
  std::deque<double> d;
  d.push_back( 3.45 );
  d.push_back( 7.89 );
  d.push_back( 2.12 );
  shifter<std::string, char> ssh( s );
  shifter<std::deque<double>, double> dsh( d );
  shifter<std::vector<int>, int> vsh( vm );

  vsh.shift( -3 );
  vsh.shift( 1 );
  ssh.shift( 27 );
  ssh.shift( 3 );
  dsh.shift( -10 );

  if( "World!Hello " == s && 5.89 < d[ 0 ] && 2.5 > d[ 1 ]  &&
      max - 1 == vm[ max - 3 ] && vm.size() == max && 3 == d.size() )
  {
    your_mark = vm.front();
  }
  
  // 3-as
  std::vector<bool> v;
  v.push_back( true );
  v.push_back( false );
  v.push_back( false );
  shifter<std::vector<bool>, bool> vbsh( v );

  vbsh >> 5;
  ssh << 16;
  2 >> ssh;
  1 << vsh;
  vsh << 2;
  dsh >> -1;
  -1 >> dsh;;

  if( v[ 2 ] && !v[ 0 ] && "Hello World!" == s && 0 == vm[ max - 3 ] &&
      5.89 < d[ 0 ] && 2.5 > d[ 1 ] && 3 == v.size() )
  {
    your_mark = vm.front();
  }
  
  // 4-es
  std::map<std::string, int> langs;
  langs[ "Haskell" ] = 4;
  langs[ "Java" ] = 5;
  langs[ "C++" ] = your_mark;
  std::map<int, double> mm;
  mm[ 7 ] = 1.23;
  mm[ 3 ] = 4.04;
  shifter<std::map<std::string, int> > msh( langs );
  shifter<std::map<int, double> > mmsh( mm );

  mmsh.shift( max );
  mmsh.shift( -5 );
  msh.shift( 1 );
  msh.shift( -2 );

  if( 3 == langs.size() && 5 == langs[ "Haskell" ] && 3 == langs[ "Java" ] &&
      1.26 > mm[ 3 ] && 3.98 < mm[ 7 ] && 2 == mm.size() )
  {
    your_mark = langs[ "C++" ];
  }
  
  /* 5-os
  std::map<std::string, int, string_size_less> ml;
  ml[ "C++" ] = your_mark;
  ml[ "Brainfuck" ] = 1;
  ml[ "Python" ] = 5;
  std::map<int, int, std::greater<int> > gm;
  gm[ 2 ] = 1;
  gm[ 5 ] = 3;
  gm[ 6 ] = 7;
  shifter<std::map<std::string, int, string_size_less> > mlsh( ml );
  shifter<std::map<int, int, std::greater<int> > > gmsh( gm );
  shifter<std::vector<int> > vs( vm );
  shifter<std::deque<double> > desh( d );
  shifter<std::string> strsh( s );

  strsh.shift( -3 );
  desh << 1;
  vs.shift( 3 );
  mlsh >> 1;
  1 << mlsh;
  gmsh << -2;
  gmsh << 1;

  if( max - 1 == vm.back() && 0 == vm[ 0 ] && 1 == gm[ 6 ] && 3 == gm[ 2 ] &&
      d[ 2 ] > 7.6 && s == "lo World!Hel" && 1 == ml[ "Python" ] && 3. > d[ 0 ] )
  {
    your_mark = ml[ ";-)" ];
  }
  */
  std::cout << "Your mark is " << your_mark << std::endl;
}
package org.cara.dojo.bankkata;


public class TestConsole implements IConsole {

  private StringBuffer printedLines = new StringBuffer();

  @Override
  public void println(String newLine) {
    printedLines.append(newLine);

  }

  public String printedLines() {
        return printedLines.toString();
  }

}

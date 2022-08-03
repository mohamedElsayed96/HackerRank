/*
 * Complete the 'acmTeam' function below.
 *
 * The function is expected to return an INTEGER_ARRAY.
 * The function accepts STRING_ARRAY topic as parameter.
 */

fun acmTeam(topics: Array<String>): Array<Int> {

    // Write your code here
    val topicMap = mutableMapOf<Int, Int>()
    var max = 0
    for(i in topics.indices){
        for (j in (i + 1)..topics.lastIndex){
            val topicI = topics[i].toBigInteger(2)
            val topicJ = topics[j].toBigInteger(2)
            val bitwise = topicI or topicJ
            val binaryString = bitwise.toString(2)
            val count = binaryString.count { it == '1' }
            if (count > max) {
                max = count
            }
             if (topicMap.containsKey(count) && topicMap[count] != null)
             {
                 topicMap[count] = topicMap[count]!!.plus(1)
             } else {
                 topicMap[count] = 1
             }
        }
    }
    return arrayOf(max, topicMap[max]!!)
}

fun main(args: Array<String>) {
    val first_multiple_input = readLine()!!.trimEnd().split(" ")

    val n = first_multiple_input[0].toInt()

    val m = first_multiple_input[1].toInt()

    val topic = Array<String>(n, { "" })
    for (i in 0 until n) {
        val topicItem = readLine()!!
        topic[i] = topicItem
    }

    val result = acmTeam(topic)

    println(result.joinToString("\n"))
}
